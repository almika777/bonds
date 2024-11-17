using Bonds.Core.Dto;
using Bonds.Core.Response;
using Bonds.Core.Services.Interfaces;

namespace Bonds.Core.Services
{
    public class BondsEventProviderService : IBondsEventProviderService
    {
        private readonly IMoexHttpDataClient _httpDataClient;

        public BondsEventProviderService(IMoexHttpDataClient httpDataClient)
        {
            _httpDataClient = httpDataClient;
        }

        public async Task<BuysSellModel?> GetBondsBuySellVolumes(string isin, DateTime? dateFrom = null)
        {
            var response = await _httpDataClient.GetBondsTrades(isin);

            bool Filter(BondsTradeResponse x)
                => (dateFrom == null || x.TradeDate >= dateFrom);

            return GetBuySellVolumes(isin, response.Where(Filter).ToList());
        }

        private BuysSellModel? GetBuySellVolumes(string isin, IReadOnlyCollection<BondsTradeResponse>? trades)
        {
            if (trades == null || trades.Count == 0)
                return null;

            var orderedTrades = trades.OrderBy(x => x.TradeDate).ToArray();
            return new BuysSellModel
            {
                ISIN = isin,
                TradesCount = trades.Count,
                FirstAvailableTrade = trades.MinBy(z => z.TradeDate)!,
                LastAvailableTrade = trades.MaxBy(z => z.TradeDate)!,
                Volumes = trades.Sum(x => x.Value),
                ChangeByDayTrades = Math.Round(orderedTrades[0].Price - orderedTrades[^1].Price, 2),
                VolumesByPrice = trades.GroupBy(x => (int)(x.Price * 100)).ToDictionary(x => x.Key, x => x.Sum(z => (int)z.Value)),
            };
        }
    }
}
