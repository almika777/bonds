using Bonds.Core.Dto;
using Bonds.Core.Services.Interfaces;
using Bonds.DataProvider.Repositories.Interfaces;

namespace Bonds.Core.Services
{
    public class NotifyGetter : INotifyGetter
    {
        private readonly IBondsEventProviderService _bondsEventProviderService;
        private readonly IUserBondsRepository _userBondsRepository;

        public NotifyGetter(IBondsEventProviderService bondsEventProviderService, IUserBondsRepository userBondsRepository)
        {
            _bondsEventProviderService = bondsEventProviderService;
            _userBondsRepository = userBondsRepository;
        }

        public async Task<List<NotifyModel>> GetNotifiesByUser(long userId)
        {
            var userBonds = await _userBondsRepository.Get(userId);
            var sellBuyModels = userBonds.ISINs
                .Select(x => _bondsEventProviderService.GetBondsBuySellVolumes(x))
                .ToList();

            await Task.WhenAll(sellBuyModels);
            
            foreach (var isin in userBonds.ISINs)
            {
                var c = await _bondsEventProviderService.GetBondsBuySellVolumes(isin);
            }


            return null;
        }
    }

    public interface INotifyGetter
    {
    }
}
