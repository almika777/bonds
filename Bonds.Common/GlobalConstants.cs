namespace Bonds.Common
{
    public static class GlobalConstants
    {
        public const string TradeSell = "S";
        public const string TradeBuy = "B";
        public const string MoexSiteBondUrlPart = "https://www.moex.com/ru/issue.aspx?board=TQCB&code=";
        public static string MoexSiteBondUrl(string isin) => $"https://www.moex.com/ru/issue.aspx?board=TQCB&code={isin}";
    }
}
