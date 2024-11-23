using Telegram.BotAPI.AvailableTypes;

namespace Bonds.Telegram.Commands
{
    public class UnknownMessageCommand : IMessageCommandHandler
    {
        public Task<Message> Handle(Message message)
        {
            return Task.FromResult(new Message
            {
                Text = "Неизвестная комманда"
            });
        }
    }
}
