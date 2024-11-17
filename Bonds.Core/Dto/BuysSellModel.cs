using Bonds.Core.Response;

namespace Bonds.Core.Dto
{
    public class BuysSellModel
    {
        /// <summary>
        /// Идентфиикатор облигации
        /// </summary>
        public string ISIN { get; set; }


        /// <summary>
        /// Количество сделок
        /// </summary>
        public int TradesCount { get; set; }

        /// <summary>
        /// Первая доступная сделка на момент запроса
        /// </summary>
        public BondsTradeResponse FirstAvailableTrade { get; set; }

        /// <summary>
        /// Последняя доступная сделка на момент запроса
        /// </summary>
        public BondsTradeResponse LastAvailableTrade { get; set; }

        /// <summary>
        /// Объем сделок
        /// </summary>
        public double Volumes { get; set; }

        /// <summary>
        /// Изменения цены за доступные сделки (скорее всего день, но не всегда так)
        /// </summary>
        public double ChangeByDayTrades { get; set; }

        /// <summary>
        /// Объем сделок в разрезе цены
        /// </summary>
        public Dictionary<int, int> VolumesByPrice { get; set; }

        /// <summary>
        /// Максимальный объем сделок по одной цене
        /// </summary>
        public KeyValuePair<int, int> MaxVolumesWithPrice => VolumesByPrice.MaxBy(x => x.Value);

        /// <summary>
        /// Минимальный объем сделок по одной цене
        /// </summary>
        public KeyValuePair<int, int> MinVolumesWithPrice => VolumesByPrice.MinBy(x => x.Value);

        /// <summary>
        /// Максимальная цена и объем по этой цене
        /// </summary>
        public KeyValuePair<int, int> MaxPriceWithVolume => VolumesByPrice.MaxBy(x => x.Key);

        /// <summary>
        /// Минимальная цена и объем по этой цене
        /// </summary>
        public KeyValuePair<int, int> MinPriceWithVolume => VolumesByPrice.MinBy(x => x.Key);

        /// <summary>
        /// Средний объем на 1 сделку
        /// </summary>
        public double AverageVolumeByTrade => Volumes / TradesCount;

    }
}
