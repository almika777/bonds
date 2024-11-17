namespace Bonds.Telegram.Services.Interfaces
{
    public interface ITelegramClient
    {
        Task Receive();

        void Stop();
    }
}
