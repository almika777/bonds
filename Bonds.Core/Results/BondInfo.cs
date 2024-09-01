using System.Text.Json.Serialization;

namespace Bonds.Core.Results
{
    public class BondInfo
    {
        /// <summary>
        /// Код ценной бумаги
        /// </summary>
        [JsonPropertyName("secid")]
        public string SecId { get; set; }

        /// <summary>
        /// Код облигации
        /// </summary>
        [JsonPropertyName("isin")]
        public string Isin { get; set; }

		/// <summary>
		/// Полное наименование
		/// </summary>
        public string Name { get; set; }

		/// <summary>
		/// Краткое наименование
		/// </summary>
        public string ShortName { get; set; }

		/// <summary>
		/// Дата начала торгов
		/// </summary>
		public DateTime IssueDate { get; set; }

        /// <summary>
        /// Дата погашения
        /// </summary>
        public DateTime MateDate { get; set; }

        /// <summary>
        /// Дата к которой рассчитывается доходность
        /// </summary>
        public DateTime BuybackDate { get; set; }

        /// <summary>
        /// Дата выплаты купона
        /// </summary>
        public DateTime CouponDate { get; set; }

        /// <summary>
        /// Ставка купона, %
        /// </summary>
        public double CouponPercent { get; set; }

        /// <summary>
        /// Сумма купона, в валюте номинала
        /// </summary>
        public double CouponValue { get; set; }

        /// <summary>
        /// Номинальная стоимость
        /// </summary>
        public double FaceValue { get; set; }

        /// <summary>
        /// Дней до погашения
        /// </summary>
        public int DaysToRedemption { get; set; }

        /// <summary>
        /// Периодичность выплаты купона в год
        /// </summary>
        public int CouponFrequency { get; set; }

        /// <summary>
        /// Периодичность выплаты купона в год
        /// </summary>
        [JsonPropertyName("EMITTER_ID")]
        public int EmitterId { get; set; }

  //       ["SECID", "Код ценной бумаги", "RU000A1077V4", "string", 1, 0, null],
		// ["NAME", "Полное наименование", "РОСЭКСИМБАНК 002P-04", "string", 3, 0, null],
		// ["SHORTNAME", "Краткое наименование", "РСЭКСМБ2Р4", "string", 4, 0, null],
		// ["REGNUMBER", "Номер государственной регистрации", "4B02-04-02790-B-002P", "string", 5, 0, null],
		// ["ISIN", "ISIN код", "RU000A1077V4", "string", 6, 0, null],
		// ["ISSUEDATE", "Дата начала торгов", "2023-11-16", "date", 7, 0, null],
		// ["MATDATE", "Дата погашения", "2033-11-03", "date", 8, 0, null],
		// ["BUYBACKDATE", "Дата к которой рассчитывается доходность", "2024-02-15", "date", 9, 0, null],
		// ["INITIALFACEVALUE", "Первоначальная номинальная стоимость", "1000", "number", 10, 0, 2],
		// ["FACEUNIT", "Валюта номинала", "SUR", "string", 11, 0, null],
		// ["LATNAME", "Английское наименование", "EXIMBANK OF RUSSIA 002P-04", "string", 12, 1, null],
		// ["STARTDATEMOEX", "Дата начала торгов на Московской Бирже", "2023-11-16", "date", 13, 0, null],
		// ["PROGRAMREGISTRYNUMBER", "Государственный регистрационный номер программы облигации", "402790B002P02E", "string", 19, 0, null],
		// ["LISTLEVEL", "Уровень листинга", "3", "number", 23, 0, 0],
		// ["DAYSTOREDEMPTION", "Дней до погашения", "3620", "number", 25, 0, 0],
		// ["ISSUESIZE", "Объем выпуска", "20000000", "number", 26, 0, 0],
		// ["FACEVALUE", "Номинальная стоимость", "1000", "number", 27, 0, 2],
		// ["ISQUALIFIEDINVESTORS", "Бумаги для квалифицированных инвесторов", "0", "boolean", 28, 0, 0],
		// ["COUPONFREQUENCY", "Периодичность выплаты купона в год", "4", "number", 30, 0, 0],
		// ["COUPONDATE", "Дата выплаты купона", "2024-02-15", "date", 31, 0, null],
		// ["COUPONPERCENT", "Ставка купона, %", "17", "number", 32, 0, 2],
		// ["COUPONVALUE", "Сумма купона, в валюте номинала", "42.38", "number", 33, 0, 2],
		// ["TYPENAME", "Вид\/категория ценной бумаги", "Биржевая облигация", "string", 71, 0, null],
		// ["GROUP", "Код типа инструмента", "stock_bonds", "string", 72, 1, null],
		// ["TYPE", "Тип бумаги", "exchange_bond", "string", 10000, 1, null],
		// ["GROUPNAME", "Типа инструмента", "Облигации", "string", 10011, 1, null],
		// ["EMITTER_ID", "Код эмитента", "672322", "number", 11000, 1, null]
    }
}
