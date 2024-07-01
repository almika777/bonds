using Bonds.Common.Options;
using Bonds.Core.Dto;
using Bonds.Core.Services.Interfaces;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Extensions.Logging;
using Tinkoff.InvestApi;
using Tinkoff.InvestApi.V1;

namespace Bonds.Core.Services
{
    public class TcsService : ITcsService
    {
        private const string BaseUrl = "https://www.tinkoff.ru/invest/bonds/";
        private readonly InvestApiClient _investApiClient;
        private readonly IMoexHttpDataClient _moexHttpDataClient;
        private readonly BondsPortfolioOptions _options;
        private readonly ILogger<TcsService> _logger;
        private readonly DateTime _startSessionTime = DateTime.UtcNow.Date.AddMinutes(410);//410 - количество минут с начала дня 
        private readonly DateTime _endSessionTime = DateTime.UtcNow.Date.AddMinutes(1070);//410 - количество минут с начала дня 

        public TcsService(
            InvestApiClient investApiClient,
            IMoexHttpDataClient moexHttpDataClient,
            BondsPortfolioOptions options,
            ILogger<TcsService> logger)
        {
            _investApiClient = investApiClient;
            _moexHttpDataClient = moexHttpDataClient;
            _options = options;
            _logger = logger;
        }

        public async Task<IEnumerable<string>> GetAllIsins()
        {
            var bonds = await _investApiClient.Instruments.BondsAsync();
            return bonds.Instruments.Select(x => x.Isin);
        }


        public async Task<List<CandleModel?>> GetProcessedBondsCandles()
        {
            var allBonds = await _moexHttpDataClient.GetAllBonds();
            var bondsWithGoodCoupon = allBonds
                .Where(x => (x.CouponPercent > _options.MinCouponPercent || x.YieldAtPrevWaPrice > 24))
                .ToList();

            var isinsWithGoodCoupons = bondsWithGoodCoupon.Select(x => x.ISIN);
            var bonds = await _investApiClient.Instruments.BondsAsync();
            var neededBonds = bonds.Instruments.Where(x => isinsWithGoodCoupons.Contains(x.Isin) 
                                                           && !_options.ExcludeNames.Any(z => x.Name?.Contains(z) ?? false)).ToList();
            var res = await Task.WhenAll(neededBonds.Select(x => GetCandles(x, CandleInterval._4Hour)).ToList());

            return res.Where(x => x != null && x.OpenCloseDifference < _options.DifferencePercent)
                .OrderBy(x => x.OpenCloseDifference)
                .ToList();

        }
        public string GetUrl(string isin) => $"{BaseUrl}{isin}";

        private static double GetDoubleFromQuote(Quotation candle)
        {
            return Math.Round(candle.Units + candle.Nano / Math.Pow(10, candle.Nano.ToString().Length), 2);
        }

        private async Task<CandleModel?> GetCandles(Bond bond, CandleInterval interval)
        {

            var res = await _investApiClient.MarketData.GetCandlesAsync(new GetCandlesRequest
            {
                From = Timestamp.FromDateTime(_startSessionTime),
                To = Timestamp.FromDateTime(_endSessionTime),
                Interval = interval,
                InstrumentId = bond.Figi,
            }).ResponseAsync;

            if (res.Candles.Count < 1)
                return null;

            return new CandleModel
            {
                Min = GetDoubleFromQuote(res.Candles.MinBy(x => GetDoubleFromQuote(x.Low))!.Low),
                Max = GetDoubleFromQuote(res.Candles.MaxBy(x => GetDoubleFromQuote(x.High))!.High),
                Open = GetDoubleFromQuote(res.Candles[0].Open),
                Close = GetDoubleFromQuote(res.Candles[^1].Close),
                OpenCloseDifference = Math.Round(GetDoubleFromQuote(res.Candles[^1].Close) - GetDoubleFromQuote(res.Candles[0].Open), 2),
                Volume = res.Candles.Sum(x => x.Volume),
                ISIN = bond.Isin,
                Name = bond.Name
            };

        }
    }
}
