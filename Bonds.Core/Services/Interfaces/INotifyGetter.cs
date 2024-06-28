using Bonds.Core.Dto;

namespace Bonds.Core.Services.Interfaces
{

    public interface INotifyGetter
    {
        Task<List<NotifyModel>> GetNotifiesByUser(long userId);
    }
}
