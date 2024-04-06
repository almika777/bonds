using System.ComponentModel.DataAnnotations.Schema;

namespace Bonds.Database.Entities
{
    public class BondQuoteEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Международный идентификационный код ценной бумаги
        /// </summary>
        public string? ISIN { get; set; }

        /// <summary>
        /// Краткое наименование бумаги
        /// </summary>
        public string? ShortName { get; set; }

        /// <summary>
        /// Цена последней сделки предыдущего торгового дня
        /// </summary>
        public double? PrevPrice { get; set; }

        /// <summary>
        /// Количество ценных бумаг в одном стандартном лоте
        /// </summary>
        public long? LotSize { get; set; }

        /// <summary>
        /// Номинальная стоимость одной ценной бумаги, в валюте инструмента
        /// </summary>
        public double? FaceValue { get; set; }

        /// <summary>
        /// Наименование режима
        /// </summary>
        public string? BoardName { get; set; }

        /// <summary>
        /// Индикатор "торговые операции разрешены/запрещены"
        /// </summary>
        public bool? Status { get; set; }

        /// <summary>
        /// Дата погашения
        /// </summary>
        public DateTime? MatDate { get; set; }

        /// <summary>
        /// Длительность купона, выраженная в днях
        /// </summary>
        public int? CouponPeriod { get; set; }

        /// <summary>
        /// Объём выпуска
        /// </summary>
        public long? IssueSize { get; set; }

        /// <summary>
        /// Цена закрытия предыдущего дня
        /// </summary>
        public double? PrevLegalClosePrice { get; set; }

        /// <summary>
        /// Дата предыдущего торгового дня
        /// </summary>
        public DateTime? PrevDate { get; set; }

        /// <summary>
        /// Наименование финансового инструмента
        /// </summary>
        public string? SecName { get; set; }

        /// <summary>
        /// Примечание
        /// </summary>
        public string? Remarks { get; set; }

        /// <summary>
        /// Код валюты, в которой выражен номинал ценной бумаги
        /// </summary>
        public string? FaceUnit { get; set; }

        /// <summary>
        /// Цена выкупа
        /// </summary>
        public string? BuybackPrice { get; set; }

        /// <summary>
        /// Дата, к которой рассчитывается доходность
        /// </summary>
        public DateTime? BuybackDate { get; set; }

        /// <summary>
        /// Наименование финансового инструмента на английском языке
        /// </summary>
        public string? LatName { get; set; }

        /// <summary>
        /// Номер государственной регистрации
        /// </summary>
        public string? RegNumber { get; set; }

        /// <summary>
        /// Код сопряженной валюты ценной бумаги
        /// </summary>
        public string? CurrencyId { get; set; }

        /// <summary>
        /// Тип ценной бумаги
        /// </summary>
        public string? SecType { get; set; }

        /// <summary>
        /// Ставка купона, %
        /// </summary>
        public double? CouponPercent { get; set; }

        /// <summary>
        /// Дата расчётов внесистемной сделки или первой части сделки РЕПО
        /// </summary>
        public DateTime? SettleDate { get; set; }
    }
}
