using Bonds.Core.Dto;

namespace Bonds.Core.Services.Interfaces
{
    public interface ITelegramMessageService
    {
        List<string> BuildBondsMessage(List<NotifyModel> notifies);
    }
}
