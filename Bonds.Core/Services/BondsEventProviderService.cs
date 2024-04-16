using Bonds.Common.Enums;
using Bonds.Common;
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

        public async Task<(BuysSellVolumes? Buy, BuysSellVolumes? Sell)> GetBondsBuySellVolumes(string isin, DateTime? dateFrom = null)
        {
            var response = await _httpDataClient.GetBondsTrades(isin);

            bool Filter(BondsTradeResponse x)
                => (dateFrom == null || x.TradeDate >= dateFrom);

            var buyTrades = response.Where(x => x.BuySell == GlobalConstants.TradeBuy && Filter(x)).ToList();
            var sellTrades = response.Where(x => x.BuySell == GlobalConstants.TradeSell && Filter(x)).ToList();

            return (GetBuySellVolumes(BuySell.Buy, buyTrades), GetBuySellVolumes(BuySell.Sell, sellTrades));
        }

        private BuysSellVolumes GetBuySellVolumes(BuySell direction, IReadOnlyCollection<BondsTradeResponse>? trades)
        {
            if (trades == null || trades.Count == 0)
                return new BuysSellVolumes();

            var orderedTrades = trades.OrderBy(x => x.TradeDate).ToArray();
            return new BuysSellVolumes
            {
                BuySell = direction,
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
