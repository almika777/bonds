using Bonds.Common.Enums;
using System.Text.Json.Serialization;

namespace Bonds.Core.Response
{
    public class BondsSecuritiesResponse
    {
        /// <summary>
        /// Международный идентификационный код ценной бумаги
        /// </summary>
        [JsonPropertyName("ISIN")]
        public string? ISIN { get; set; }

        /// <summary>
        /// Идентификатор режима финансовых инструментов, для которого определено событие
        /// </summary>
        [JsonPropertyName("BOARDID")]
        public string? BoardId { get; set; }

        /// <summary>
        /// Краткое наименование бумаги
        /// </summary>
        [JsonPropertyName("SHORTNAME")]
        public string? ShortName { get; set; }

        /// <summary>
        /// Значение оценки предыдущего торгового дня
        /// </summary>
        [JsonPropertyName("PREVWAPRICE")]
        public string? PrevWAPrice { get; set; }

        /// <summary>
        /// Доходность по оценке предыдущего торгового дня
        /// </summary>
        [JsonPropertyName("YIELDATPREVWAPRICE")]
        public double? YieldAtPrevWAPrice { get; set; }

        /// <summary>
        /// Величина купона, выраженная в руб
        /// </summary>
        [JsonPropertyName("COUPONVALUE")]
        public double? CouponValue { get; set; }

        /// <summary>
        /// Дата окончания купона
        /// </summary>
        [JsonPropertyName("NEXTCOUPON")]
        public DateTime? NextCouponDate { get; set; }

        /// <summary>
        /// Цена последней сделки предыдущего торгового дня
        /// </summary>
        [JsonPropertyName("PREVPRICE")]
        public double? PrevPrice { get; set; }

        /// <summary>
        /// Количество ценных бумаг в одном стандартном лоте
        /// </summary>
        [JsonPropertyName("LOTSIZE")]
        public long? LotSize { get; set; }

        /// <summary>
        /// Номинальная стоимость одной ценной бумаги, в валюте инструмента
        /// </summary>
        [JsonPropertyName("FACEVALUE")]
        public double? FaceValue { get; set; }

        /// <summary>
        /// Наименование режима
        /// </summary>
        [JsonPropertyName("BOARDNAME")]
        public string? BoardName { get; set; }

        /// <summary>
        /// Индикатор "торговые операции разрешены/запрещены"
        /// </summary>
        [JsonPropertyName("STATUS")]
        public bool? Status { get; set; }

        /// <summary>
        /// Дата погашения
        /// </summary>
        [JsonPropertyName("MATDATE")]
        public DateTime? MatDate { get; set; }

        /// <summary>
        /// Длительность купона, выраженная в днях
        /// </summary>
        [JsonPropertyName("COUPONPERIOD")]
        public int? CouponPeriod { get; set; }

        /// <summary>
        /// Объём выпуска
        /// </summary>
        [JsonPropertyName("ISSUESIZE")]
        public long? IssueSize { get; set; }

        /// <summary>
        /// Цена закрытия предыдущего дня
        /// </summary>
        [JsonPropertyName("PREVLEGALCLOSEPRICE")]
        public double? PrevLegalClosePrice { get; set; }

        /// <summary>
        /// Дата предыдущего торгового дня
        /// </summary>
        [JsonPropertyName("PREVDATE")]
        public DateTime? PrevDate { get; set; }

        /// <summary>
        /// Наименование финансового инструмента
        /// </summary>
        [JsonPropertyName("SECNAME")]
        public string? SecName { get; set; }

        /// <summary>
        /// Примечание
        /// </summary>
        [JsonPropertyName("REMARKS")]
        public string? Remarks { get; set; }

        /// <summary>
        /// Код валюты, в которой выражен номинал ценной бумаги
        /// </summary>
        [JsonPropertyName("FACEUNIT")]
        public string? FACEUNIT { get; set; }

        /// <summary>
        /// Цена выкупа
        /// </summary>
        [JsonPropertyName("BUYBACKPRICE")]
        public string? BuybackPrice { get; set; }

        /// <summary>
        /// Дата, к которой рассчитывается доходность
        /// </summary>
        [JsonPropertyName("BUYBACKDATE")]
        public DateTime? BuybackDate { get; set; }

        /// <summary>
        /// Наименование финансового инструмента на английском языке
        /// </summary>
        [JsonPropertyName("LATNAME")]
        public string? LatName { get; set; }

        /// <summary>
        /// Номер государственной регистрации
        /// </summary>
        [JsonPropertyName("REGNUMBER")]
        public string? RegNumber { get; set; }

        /// <summary>
        /// Код сопряженной валюты ценной бумаги
        /// </summary>
        [JsonPropertyName("CURRENCYID")]
        public string? CurrencyId { get; set; }

        /// <summary>
        /// Тип ценной бумаги
        /// </summary>
        [JsonPropertyName("SECTYPE")]
        public string? SecType { get; set; }

        /// <summary>
        /// Ставка купона, %
        /// </summary>
        [JsonPropertyName("COUPONPERCENT")]
        public double? CouponPercent { get; set; }

        /// <summary>
        /// Дата расчётов внесистемной сделки или первой части сделки РЕПО
        /// </summary>
        [JsonPropertyName("SETTLEDATE")]
        public DateTime? SettleDate { get; set; }
    }
}
