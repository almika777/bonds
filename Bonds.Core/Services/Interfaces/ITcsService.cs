using Bonds.Core.Dto;

namespace Bonds.Core.Services.Interfaces
{
    public interface ITcsService
    {
        Task<IEnumerable<string>> GetAllIsins();
        Task<List<CandleModel?>> GetProcessedBondsCandles();
        string GetUrl(string isin);
    }
}
