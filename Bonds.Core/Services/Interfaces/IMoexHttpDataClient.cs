using Bonds.Core.Response;

namespace Bonds.Core.Services.Interfaces
{
    public interface IMoexHttpDataClient
    {
        Task<MoexBondsInfoResponse?> GetBondsInfo(string isin);
        Task<List<BondsSecuritiesResponse>> GetAllBonds();
        Task<List<BondsTradeResponse>> GetBondsTrades(string isin);
    }
}
