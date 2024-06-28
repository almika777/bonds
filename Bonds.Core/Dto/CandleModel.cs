namespace Bonds.Core.Dto
{
    public class CandleModel
    {
        public string ISIN { get; set; }
        public string Name { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
        public double OpenCloseDifference { get; set; }
        public long Volume { get; set; }
        public int IntervalMinutes { get; set; }
    }
}
