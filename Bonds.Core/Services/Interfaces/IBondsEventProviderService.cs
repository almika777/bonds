using Bonds.Core.Dto;

namespace Bonds.Core.Services.Interfaces
{
    public interface IBondsEventProviderService
    {
        /// <summary>
        /// Аггрегирует данные по сделкам
        /// </summary>
        /// <param name="isin"></param>
        /// <returns>Аггрегированные данные по сделкам</returns>
        Task<BuysSellModel?> GetBondsBuySellVolumes(string isin, DateTime? dateFrom = null);
    }
}
