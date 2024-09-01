using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bonds.DataProvider.Entities
{
    public class BondEntity
    {

        /// <summary>
        /// Международный идентификационный код ценной бумаги
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ISIN { get; set; }

        /// <summary>
        /// Лучшая котировка на покупку
        /// </summary>
        public double? Bid { get; set; }

        /// <summary>
        /// Лучшая котировка на продажу
        /// </summary>
        public double? Ask { get; set; }

        /// <summary>
        /// Разница в цене, между продажей и покупкой инструмента
        /// </summary>
        public double? Spread { get; set; }

        /// <summary>
        /// Цена первой сделки
        /// </summary>
        public double Open { get; set; }

        /// <summary>
        /// Минимальная цена сделки
        /// </summary>
        public double Low { get; set; }

        /// <summary>
        /// Максимальная цена сделки
        /// </summary>
        public double High { get; set; }

        /// <summary>
        /// Цена последней сделки
        /// </summary>
        public double Last { get; set; }

        /// <summary>
        /// Объем последней сделки, в лотах
        /// </summary>
        public double Qty { get; set; }

        /// <summary>
        /// Объем последней сделки, выраженный в валюте расчетов
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Доходность, рассчитанная по цене сделки
        /// </summary>
        public double Yield { get; set; }

        /// <summary>
        /// Средневзвешенная цена
        /// </summary>
        public double WaPrice { get; set; }

        /// <summary>
        /// Доходность по средневзвешенной цене
        /// </summary>
        public double YieldAtWaPrice { get; set; }

        /// <summary>
        /// Размер купона
        /// </summary>
        public double CouponValue { get; set; }

        /// <summary>
        /// Рыночная цена по результатам торгов сегодняшнего дня, за одну ценную бумагу
        /// </summary>
        public double MarketPriceToday { get; set; }

        /// <summary>
        /// Рыночная цена ценной бумаги по результатам торгов предыдущего дня, за одну ценную бумагу
        /// </summary>
        public double MarketPrice { get; set; }

        /// <summary>
        /// Количество сделок за торговый день
        /// </summary>
        public double TradesCount { get; set; }

        /// <summary>
        /// Объем совершенных сделок, выраженный в единицах ценных бумаг
        /// </summary>
        public long VolToday { get; set; }

        /// <summary>
        /// Объем совершенных сделок, выраженный в валюте расчетов
        /// </summary>
        public long ValToday { get; set; }

        /// <summary>
        /// Дата изменения в MOEX
        /// </summary>
        public DateTime UpdateTime { get; set; }

        /// <summary>
        /// Изменение цены последней сделки по отношению к цене последней сделки предыдущего торгового
        /// </summary>
        public double Change { get; set; }

        /// <summary>
        /// Цена последней сделки к оценке предыдущего дня
        /// </summary>
        public double PriceMinusPrevWaPrice { get; set; }

        /// <summary>
        /// Доходность купона
        /// </summary>
        public double YieldLastCoupon { get; set; }

        /// <summary>
        /// Доходность купона
        /// </summary>
        public double SeqNum { get; set; }
        public DateTime UpdatedDate { get; set; }

    }
}
