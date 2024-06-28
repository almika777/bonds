namespace Bonds.Common.Options;

public class BondsPortfolioOptions
{
    public string[] ExcludeNames { get; set; }
    public double DifferencePercent { get; set; }
    public double MinCouponPercent { get; set; }
}