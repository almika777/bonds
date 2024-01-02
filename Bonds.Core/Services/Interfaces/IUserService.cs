using Bonds.Common.Entities;

namespace Bonds.Core.Services.Interfaces
{
    public interface IUserService
    {
        Task Add(UserEntity entity);
        Task<UserEntity?> Get(int id);
    }
}
