namespace Bonds.Common.Options;

public class BondsPortfolioOptions
{
    public string[] ISINs { get; set; }
    public double DifferencePercentMinus { get; set; }
    public double DifferencePercentPlus { get; set; }
}