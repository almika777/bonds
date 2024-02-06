using Bonds.Core.Response;

namespace Bonds.Core.Services.Interfaces
{
    public interface IBondsDataClient
    {
        Task<MoexBondsInfoResponse> GetBondsInfo(string isin);
        Task GetBondQuotes(string isin);
        Task<string> GetBondsQuotes();
        Task<string> GetDayResult();
    }
}
