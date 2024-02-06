namespace Bonds.Core.Services.Interfaces
{
    public interface IPasswordService
    {
        bool Verify(string password, string hash);
        string Generate(string password);
    }
}
