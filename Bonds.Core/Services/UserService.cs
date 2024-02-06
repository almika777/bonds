using Bonds.Common.Entities;
using Bonds.Core.Services.Interfaces;
using Bonds.Database;
using Microsoft.EntityFrameworkCore;

namespace Bonds.Core.Services
{
    public class UserService : IUserService
    {
        private readonly BondsContext _context;
        private readonly IPasswordService _passwordService;

        public UserService(BondsContext context, IPasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }

        public async Task Add(UserEntity entity)
        {
            
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task Add(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity?> Get(int id)
        {
            return _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
