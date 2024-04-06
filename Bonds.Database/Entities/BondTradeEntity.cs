using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Bonds.Database.Entities
{
    public class BondTradeEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор сделки
        /// </summary>
        [JsonPropertyName("TRADENO")]
        public long TradeId { get; set; }

        /// <summary>
        /// Дата и время регистрации сделки 
        /// </summary>
        [JsonPropertyName("TRADETIME_GRP")]
        public DateTime TradeDate { get; set; }

        /// <summary>
        /// Идентификатор инструмента
        /// </summary>
        [JsonPropertyName("SECID")]
        public string SecId { get; set; }

        /// <summary>
        /// Цена за 1 бумагу
        /// </summary>
        [JsonPropertyName("PRICE")]
        public double Price { get; set; }

        /// <summary>
        /// Объём сделки, выраженный в лотах
        /// </summary>
        [JsonPropertyName("QUANTITY")]
        public int Quantity { get; set; }

        /// <summary>
        /// Объём сделки, выраженный в руб
        /// </summary>
        [JsonPropertyName("VALUE")]
        public double Value { get; set; }

        /// <summary>
        /// Доходность, рассчитанная по цене сделки
        /// </summary>
        [JsonPropertyName("YIELD")]
        public double Yield { get; set; }

        /// <summary>
        /// Направленность заявки - "купля/продажа"
        /// </summary>
        [JsonPropertyName("BUYSELL")]
        public string BuySell { get; set; }
    }
}
