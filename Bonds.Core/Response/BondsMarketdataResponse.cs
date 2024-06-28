using System.Text.Json.Serialization;

namespace Bonds.Core.Response
{
    public class BondsMarketdataResponse
    {
        /// <summary>
        /// Международный идентификационный код ценной бумаги
        /// </summary>
        [JsonPropertyName("secid")]
        public string? ISIN { get; set; }

        /// <summary>
        /// Лучшая котировка на покупку
        /// </summary>
        [JsonPropertyName("bid")]
        public double? Bid { get; set; }

        /// <summary>
        /// Лучшая котировка на продажу
        /// </summary>
        [JsonPropertyName("offer")]
        public double? Ask { get; set; }

        /// <summary>
        /// Разница в цене, между продажей и покупкой инструмента
        /// </summary>
        [JsonPropertyName("spread")]
        public double? Spread { get; set; }

        /// <summary>
        /// Цена первой сделки
        /// </summary>
        [JsonPropertyName("open")]
        public double Open { get; set; }

        /// <summary>
        /// Минимальная цена сделки
        /// </summary>
        [JsonPropertyName("low")]
        public double Low { get; set; }

        /// <summary>
        /// Максимальная цена сделки
        /// </summary>
        [JsonPropertyName("high")]
        public double High { get; set; }

        /// <summary>
        /// Цена последней сделки
        /// </summary>
        [JsonPropertyName("last")]
        public double Last { get; set; }

        /// <summary>
        /// Объем последней сделки, в лотах
        /// </summary>
        [JsonPropertyName("qty")]
        public double Qty { get; set; }

        /// <summary>
        /// Объем последней сделки, выраженный в валюте расчетов
        /// </summary>
        [JsonPropertyName("VALUE")]
        public double Value { get; set; }

        /// <summary>
        /// Доходность, рассчитанная по цене сделки
        /// </summary>
        [JsonPropertyName("YIELD")]
        public double Yield { get; set; }

        /// <summary>
        /// Средневзвешенная цена
        /// </summary>
        [JsonPropertyName("WAPRICE")]
        public double WaPrice { get; set; }

        /// <summary>
        /// Доходность по средневзвешенной цене
        /// </summary>
        [JsonPropertyName("YIELDATWAPRICE")]
        public double YieldAtWaPrice { get; set; }       
        
        /// <summary>
        /// Размер купона
        /// </summary>
        [JsonPropertyName("COUPONVALUE")]
        public double CouponValue { get; set; }

        /// <summary>
        /// Рыночная цена по результатам торгов сегодняшнего дня, за одну ценную бумагу
        /// </summary>
        [JsonPropertyName("MARKETPRICETODAY")]
        public double MarketPriceToday { get; set; }

        /// <summary>
        /// Рыночная цена ценной бумаги по результатам торгов предыдущего дня, за одну ценную бумагу
        /// </summary>
        [JsonPropertyName("MARKETPRICE")]
        public double MarketPrice { get; set; }

        /// <summary>
        /// Количество сделок за торговый день
        /// </summary>
        [JsonPropertyName("NUMTRADES")]
        public double TradesCount { get; set; }


        /// <summary>
        /// Объем совершенных сделок, выраженный в единицах ценных бумаг
        /// </summary>
        [JsonPropertyName("VOLTODAY")]
        public double VolToday { get; set; }

        /// <summary>
        /// Объем совершенных сделок, выраженный в валюте расчетов
        /// </summary>
        [JsonPropertyName("VALTODAY")]
        public double ValToday { get; set; }       
        
        /// <summary>
        /// Дата изменения
        /// </summary>
        [JsonPropertyName("UPDATETIME")]
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// Изменение цены последней сделки по отношению к цене последней сделки предыдущего торгового
        /// </summary>
        [JsonPropertyName("CHANGE")]
        public double Change { get; set; }

        /// <summary>
        /// Цена последней сделки к оценке предыдущего дня
        /// </summary>
        [JsonPropertyName("PRICEMINUSPREVWAPRICE")]
        public double PriceMinusPrevWaPrice { get; set; }        
        
        /// <summary>
        /// Доходность купона
        /// </summary>
        [JsonPropertyName("YIELDLASTCOUPON")]
        public double YieldLastCoupon { get; set; }
    }
}
