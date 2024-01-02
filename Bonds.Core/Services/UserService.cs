using Bonds.Common.Entities;
using Bonds.Core.Services.Interfaces;
using Bonds.Database;
using Microsoft.EntityFrameworkCore;

namespace Bonds.Core.Services
{
    public class UserService : IUserService
    {
        private readonly BondsContext _context;

        public UserService(BondsContext context)
        {
            _context = context;
        }

        public async Task Add(UserEntity entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task<UserEntity?> Get(int id)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
