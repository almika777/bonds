using Bonds.Core.Services.Interfaces;

namespace Bonds.Core.Jobs
{
    public class MoexBondInfoJob : IMoexBondInfoJob
    {
        private readonly IMoexHttpDataClient _moexHttpDataClient;

        public MoexBondInfoJob(IMoexHttpDataClient moexHttpDataClient)
        {
            _moexHttpDataClient = moexHttpDataClient;
        }

        public async Task Execute()
        {
            var bondsInfo = await _moexHttpDataClient.GetAllBondsMarketdata();
        }
    }

    public interface IMoexBondInfoJob : IJob
    {
    }
}
