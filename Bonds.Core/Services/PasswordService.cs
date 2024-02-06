using Bonds.Core.Services.Interfaces;

namespace Bonds.Core.Services
{
    public class PasswordService : IPasswordService
    {
        public bool Verify(string password, string hash)
            => BCrypt.Net.BCrypt.EnhancedVerify(password, hash);

        public string Generate(string password)
            => BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);
    }
}
