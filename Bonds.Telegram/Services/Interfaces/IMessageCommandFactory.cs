using Bonds.Telegram.Commands;

namespace Bonds.Telegram.Services.Interfaces
{
    public interface IMessageCommandFactory
    {
        IMessageCommandHandler Handler(string command);
    }
}
