namespace Bonds.Telegram.Services.Interfaces
{
    public interface ITelegramService
    {
        Task SendMessage(string chatId, string message);
    }
}
