using AutoMapper;
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
                _logger.LogInformation("Забираем данные с МОЕХ: {Date}", DateTime.UtcNow);

                await using var context = await _factory.CreateDbContextAsync();

                var moexBonds = (await _moexHttpDataClient.GetAllBondsSecurities())
                    .Select(_mapper.Map<BondEntity>)
                    .ToList();

                var dbBonds = context.Bonds
                    .Select(x => x.ISIN)
                    .AsNoTracking()
                    .ToHashSet();

                _logger.LogInformation("Обновить: {Count}", moexBonds.Count);

                var (addBonds, updateBonds) = SplitCollection(moexBonds, entity => !dbBonds.Contains(entity.ISIN));
                await context.Bonds.AddRangeAsync(addBonds);
                await context.SaveChangesAsync();

                context.Bonds.UpdateRange(updateBonds);
                await context.SaveChangesAsync();

                _logger.LogInformation("Сохранили: {Date}", DateTime.UtcNow);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
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
