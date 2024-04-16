using Bonds.Common.Options;
using Bonds.DataProvider.Models;
using Bonds.DataProvider.Repositories.Interfaces;

namespace Bonds.DataProvider.Repositories
{
    public class UserBondsRepository : IUserBondsRepository
    {
        private readonly BondsPortfolioOptions _options;

        public UserBondsRepository(BondsPortfolioOptions options)
        {
            _options = options;
        }

        public async Task<UserProfileModel> Get(long userId)
        {
            return new UserProfileModel
            {
                ISINs = _options.ISINs,
                DifferencePercentMinus = _options.DifferencePercentMinus,
                DifferencePercentPlus = _options.DifferencePercentPlus
            };
        }
    }


}