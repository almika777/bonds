using Microsoft.Extensions.Caching.Memory;

namespace Bonds.Core.Services
{
    public class BondCacheService
    {
        private readonly IMemoryCache _cache;

        public BondCacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

         
    }
}
