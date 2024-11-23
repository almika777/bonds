using AutoMapper;
using Bonds.Core.Response;
using Bonds.DataProvider.Entities;

namespace Bonds.Core.Mappers
{
    public class BondMapper : Profile
    {
        public BondMapper()
        {
            CreateMap<BondsSecuritiesResponse, BondSecurityEntity>()
                .ForMember(x => x.UpdatedDate, x => x.MapFrom(z => DateTime.UtcNow))
                .ForMember(x => x.IsFloater, x => x.MapFrom(z => z.CouponPercent == null && z.CouponValue == 0 && z.YieldAtPrevWaPrice == 0));

            CreateMap<BondsMarketdataResponse, BondsMarketdataEntity>()
                .ForMember(x => x.UpdatedDate, x => x.MapFrom(z => DateTime.UtcNow));
        }
    }
}
