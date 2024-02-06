using Bonds.Common.Entities;

namespace Bonds.Core.Services.Interfaces
{
    public interface IUserService
    {
        Task Add(string email, string password);
        Task<UserEntity?> Get(int id);
    }
}
