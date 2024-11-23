using AutoMapper;
using Bonds.Core.Response;
using Bonds.Core.Services.Interfaces;
using Bonds.DataProvider;
using Bonds.DataProvider.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bonds.Core.Jobs
{
    public class MoexBondInfoJob : IMoexBondInfoJob
    {
        private readonly IMoexHttpDataClient _moexHttpDataClient;
        private readonly IMapper _mapper;
        private readonly IDbContextFactory<BondsContext> _factory;
        private readonly ILogger<MoexBondInfoJob> _logger;

        public MoexBondInfoJob(
            IMoexHttpDataClient moexHttpDataClient,
            IMapper mapper,
            IDbContextFactory<BondsContext> factory,
            ILogger<MoexBondInfoJob> logger)
        {
            _moexHttpDataClient = moexHttpDataClient;
            _mapper = mapper;
            _factory = factory;
            _logger = logger;
        }

        public async Task Execute()
        {
            try
            {
                _logger.LogInformation("Забираем данные (MARKETDATA) с МОЕХ: {Date}", DateTime.UtcNow);

                await using var context = await _factory.CreateDbContextAsync();

                var moex = await _moexHttpDataClient.GetAllBondsMarketdataAndSecurity();

                await UpdateBonds<BondsMarketdataResponse, BondsMarketdataEntity>(
                    moex.Marketdata, 
                    context);                
                
                await UpdateBonds<BondsSecuritiesResponse, BondSecurityEntity>(
                    moex.Securities, 
                    context);

                _logger.LogInformation("Сохранили: {Date}", DateTime.UtcNow);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
        }

        private async Task UpdateBonds<T,TK>(
            IEnumerable<T> marketdatas, 
            DbContext context) where TK : class, IBondEntity
        {
            var marketdata = marketdatas
                .Select(x => _mapper.Map<TK>(x))
                .ToList();

            var dbMarketdataBonds = context.Set<TK>()
                .Select(x => x.ISIN)
                .AsNoTracking()
                .ToHashSet();

            var (addBonds, updateBonds) = SplitCollection(marketdata, entity => !dbMarketdataBonds.Contains(entity.ISIN));
            await context.Set<TK>().AddRangeAsync(addBonds);
            await context.SaveChangesAsync();

            context.Set<TK>().UpdateRange(updateBonds);
            await context.SaveChangesAsync();
        }

        private (IEnumerable<T>, IEnumerable<T>) SplitCollection<T>(IEnumerable<T> source, Func<T, bool> filter)
        {
            var res1 = new List<T>();
            var res2 = new List<T>();
            foreach (var entry in source)
            {
                if (filter(entry))
                    res1.Add(entry);
                else
                    res2.Add(entry);
            }
            return (res1, res2);
        }

    }

    public interface IMoexBondInfoJob : IJob
    {
    }
}
