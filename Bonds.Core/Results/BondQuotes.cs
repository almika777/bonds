namespace Bonds.Core.Results
{
    public class BondQuotes
    {
        /// <summary>
        /// Код ценной бумаги
        /// </summary>
        public string SecId { get; set; }

        /// <summary>
        /// Идентификатор режима торгов
        /// </summary>
        public string BoardId { get; set; }

        /// <summary>
		/// Краткое наименование
		/// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Значение оценки предыдущего торгового дня
        /// </summary>
        public string PrevWapPrice { get; set; }

		/// <summary>
		/// Дата начала торгов
		/// </summary>
		public DateTime IssueDate { get; set; }

        /// <summary>
        /// Дата погашения
        /// </summary>
        public DateTime MatDate { get; set; }

        /// <summary>
        /// Дата к которой рассчитывается доходность
        /// </summary>
        public DateTime BuybackDate { get; set; }

        /// <summary>
        /// Дата выплаты купона
        /// </summary>
        public DateTime CouponDate { get; set; }

        /// <summary>
        ///	Накопленный купонный доход на дату торгов в расчёте на одну бумагу, выраженный в руб
        /// </summary>
        public double Accruedint { get; set; }

        /// <summary>
        /// Цена последней сделки предыдущего торгового дня
        /// </summary>
        public double PrevPrice { get; set; }

        /// <summary>
        /// Номинальная стоимость
        /// </summary>
        public double FaceValue { get; set; }

        /// <summary>
        /// Величина купона, выраженная в %
        /// </summary>
        public double CouponPercent { get; set; }

        /// <summary>
        /// Дней до погашения
        /// </summary>
        public int DaysToRedemption { get; set; }

        /// <summary>
        /// Периодичность выплаты купона в год
        /// </summary>
        public int CouponFrequency { get; set; }

        /// <summary>
        /// Длительность купона, выраженная в днях
        /// </summary>
        public int CouponPeriod { get; set; }

        /// <summary>
        /// Объём выпуска
        /// </summary>
        public int IssueSize { get; set; }

        /// <summary>
        /// Количество размещенных бумаг
        /// </summary>
        public int IssueSizePlaced { get; set; }
    }
}
