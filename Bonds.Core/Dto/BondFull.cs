using Bonds.DataProvider.Entities;

namespace Bonds.Core.Dto
{
    public class BondFull
    {
        public BondsMarketdataEntity Marketdata { get; set; }
        public BondSecurityEntity Security { get; set; }
        public BondExtendedEntity Extended { get; set; }
    }
}
