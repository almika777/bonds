using Bonds.Telegram.Commands;
using Bonds.Telegram.Services.Interfaces;

namespace Bonds.Telegram.Services
{
    public class MessageCommandFactory : IMessageCommandFactory
    {
        private readonly IDictionary<Type, IMessageCommandHandler> _handlers;

        public MessageCommandFactory(IEnumerable<IMessageCommandHandler> handlers)
        {
            _handlers = handlers.ToDictionary(x => x.GetType());
        }

        public IMessageCommandHandler Handler(string command)
        {
            return command switch
            {
                _ => _handlers[typeof(UnknownMessageCommand)]
            };
        }
    }
}
