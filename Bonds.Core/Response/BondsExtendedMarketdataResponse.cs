namespace Bonds.Core.Response
{
    public class BondsExtendedMarketdataResponse
    {
        public string ISIN { get; set; }

        public string? ShortName { get; set; }

        public string? Name { get; set; }

        public long? EmitterId { get; set; }
    }
}
