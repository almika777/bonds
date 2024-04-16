using Bonds.DataProvider.Models;

namespace Bonds.DataProvider.Repositories.Interfaces
{
    public interface IUserBondsRepository
    {
        Task<UserProfileModel> Get(long userId);
    }
}
