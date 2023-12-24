using Bonds.Core.Dto;
using Bonds.Core.Results;

namespace Bonds.Core.Services.Interfaces
{
    public interface IProfitabilityCalculatorService
    {
        Task<double> Calculate(ProfitabilityDto model);
        double GetNkd(BondInfo data);
    }
}
