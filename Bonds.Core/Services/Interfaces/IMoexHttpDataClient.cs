using Bonds.Core.Response;

namespace Bonds.Core.Services.Interfaces
{
    public interface IMoexHttpDataClient
    {
        Task<BondsExtendedMarketdataResponse> GetBondExtendedData(string isin);

        /// <summary>
        /// Список всех облигаций на бирже
        /// </summary>
        /// <returns></returns>
        Task<List<BondsSecuritiesResponse>> GetAllBonds();

        Task<List<BondsMarketdataResponse>> GetAllBondsMarketdata();
        Task<List<BondsSecuritiesResponse>> GetAllBondsSecurities();
        Task<(List<BondsMarketdataResponse> Marketdata, List<BondsSecuritiesResponse> Securities)> 
            GetAllBondsMarketdataAndSecurity();
        Task<List<BondsTradeResponse>> GetBondsTrades(string isin);
    }
}
