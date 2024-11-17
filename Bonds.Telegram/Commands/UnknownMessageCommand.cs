using Telegram.BotAPI.AvailableTypes;

namespace Bonds.Telegram.Commands
{
    public class UnknownMessageCommand : IMessageCommandHandler
    {
        public Task<Message> Handle(string value)
        {
            return Task.FromResult(new Message
            {
                Text = "Неизвестная комманда"
            });
        }
    }
}
