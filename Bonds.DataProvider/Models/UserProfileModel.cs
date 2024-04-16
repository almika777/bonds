namespace Bonds.DataProvider.Models
{
    public class UserProfileModel
    {
        public IList<string> ISINs { get; set; }
        public double DifferencePercentMinus { get; set; }
        public double DifferencePercentPlus { get; set; }
    }
}
