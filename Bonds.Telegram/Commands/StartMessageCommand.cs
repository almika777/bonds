using Telegram.BotAPI.AvailableTypes;

namespace Bonds.Telegram.Commands
{
    public class StartMessageCommand : IMessageCommandHandler
    {
        public Task<Message> Handle(Message message)
        {
            return Task.FromResult(new Message
            {
                Text = $"Привет {message.From.FirstName}, я бот для получения информации по облигациям" + 
                       Environment.NewLine +
                       Environment.NewLine +
                       $"Чтобы получить информацию, нужно отправить ISIN Облигации" +
                       $""
            });
        }


    }
}
