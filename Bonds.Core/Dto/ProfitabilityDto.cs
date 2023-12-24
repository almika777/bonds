using Bonds.Core.Enums;

namespace Bonds.Core.Dto
{
    public class ProfitabilityDto
    {
        /// <summary>
        /// Международный идентификационный код ценной бумаги
        /// </summary>
        public string Isin { get; set; }

        /// <summary>
        /// Цена покупки бумаги
        /// </summary>
        public double PriceOfPurchase { get; set; }

        /// <summary>
        /// Дата покупки бумаги
        /// </summary>
        public DateTime DateOfPurchase { get; set; }

        /// <summary>
        /// Тип расчета доходности
        /// </summary>
        public ProfitabilityType ProfitabilityType { get; set; }
    }
}
