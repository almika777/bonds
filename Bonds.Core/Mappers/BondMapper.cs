using Bonds.Core.Response;
using Bonds.DataProvider.Entities;
using Nelibur.ObjectMapper;

namespace Bonds.Core.Mappers
{
    public class BondMapper
    {
        public BondMapper()
        {
            TinyMapper.Bind<BondsSecuritiesResponse, BondEntity>();
        }
    }
}
