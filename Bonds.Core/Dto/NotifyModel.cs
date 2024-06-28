namespace Bonds.Core.Dto
{
    public class NotifyModel
    {
        public string ISIN { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public double DifferencePercent { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
    }
}
