using Bonds.Telegram.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Telegram.BotAPI;
using Telegram.BotAPI.AvailableMethods;
using Telegram.BotAPI.AvailableTypes;
using Telegram.BotAPI.GettingUpdates;

namespace Bonds.Telegram.Services
{
    public class UpdateHandler : IUpdateHandler
    {
        private readonly ITelegramBotClient _telegramBot;
        private readonly IIsinHandler _isinHandler;
        private readonly IMessageCommandFactory _messageCommandFactory;
        private readonly ILogger<UpdateHandler> _logger;

        public UpdateHandler(
            ITelegramBotClient telegramBot, 
            IIsinHandler isinHandler,
            IMessageCommandFactory messageCommandFactory,
            ILogger<UpdateHandler> logger)
        {
            _telegramBot = telegramBot;
            _isinHandler = isinHandler;
            _logger = logger;
            _messageCommandFactory = messageCommandFactory;
        }

        public async Task Update(Update update)
        {
            await (update switch
            {
                { Message: { } message } => OnMessage(message),
                //{ EditedMessage: { } message } => OnMessage(message),
                _ => UnknownUpdateHandlerAsync(update)
            });
        }

        private async Task OnMessage(Message msg)
        {
            if (msg.Text is not { } messageText)
                return;

            try
            {
                var isCommand = msg.Entities?.FirstOrDefault(x => x.Type == MessageEntityTypes.BotCommand) != null;
                if (!isCommand)
                {
                    await HandleNotCommand(msg, messageText);
                    return;
                }
                var split = messageText.Split(' ');
                var command = split[0];
                var message = await _messageCommandFactory.Handler(command).Handle(msg);
                await _telegramBot.SendMessageAsync(msg.Chat.Id, message.Text, parseMode:FormatStyles.HTML);
            }
            catch (Exception e)
            {
                var errorText = "Ошибка при обработке сообщения";

                _logger.LogError(e, e.Message);
                await _telegramBot.SendMessageAsync(msg.Chat.Id, e.Message);
            }
        }

        private async Task HandleNotCommand(Message msg, string messageText)
        {
            var message = await _isinHandler.Handle(messageText);
            await _telegramBot.SendMessageAsync(msg.Chat.Id, message.Text, parseMode: FormatStyles.HTML);
        }

        private Task UnknownUpdateHandlerAsync(Update update)
        {
            _logger.LogInformation("Unknown update type: {Update}", update);
            return Task.CompletedTask;
        }
    }
}
