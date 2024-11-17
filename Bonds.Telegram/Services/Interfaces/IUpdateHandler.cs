using Telegram.BotAPI.GettingUpdates;

namespace Bonds.Telegram.Services.Interfaces
{
    public interface IUpdateHandler
    {
        Task Update(Update update);
    }
}
