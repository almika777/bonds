using AutoMapper;
using Bonds.Core.Response;
using Bonds.DataProvider.Entities;

namespace Bonds.Core.Mappers
{
    public class BondMapper : Profile
    {
        public BondMapper()
        {
            CreateMap<BondsMarketdataResponse, BondEntity>()
                .ForMember(x => x.UpdatedDate, x => x.MapFrom(z => DateTime.UtcNow));
        }
    }
}
