using Telegram.BotAPI.AvailableTypes;

namespace Bonds.Telegram.Commands
{
    public interface IMessageCommandHandler
    {
        Task<Message> Handle(Message message);
    }
}
