using Bonds.Core.Response;
using Bonds.DataProvider.Entities;
using Nelibur.ObjectMapper;

namespace Bonds.Core.Mappers
{
    public class SimpleMapper
    {
        public SimpleMapper()
        {
            TinyMapper.Bind<BondsSecuritiesResponse, BondEntity>();
            TinyMapper.Bind<BondEntity, BondsSecuritiesResponse>();
        }
    }
}
