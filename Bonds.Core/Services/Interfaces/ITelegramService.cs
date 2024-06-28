namespace Bonds.Core.Services.Interfaces
{
    public interface ITelegramService
    {
        Task SendMessage(string chatId, string message);
    }
}
