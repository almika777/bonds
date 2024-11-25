using Bonds.Core.Services.Interfaces;
using Bonds.DataProvider;
using Bonds.DataProvider.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Bonds.Core.Jobs
{
    public class MoexExtendedBondInfoJob : IJob
    {
        private readonly IMoexHttpDataClient _moexHttpDataClient;
        private readonly IDbContextFactory<BondsContext> _factory;
        private readonly ILogger<MoexBondInfoJob> _logger;

        public MoexExtendedBondInfoJob(
            IMoexHttpDataClient moexHttpDataClient,
            IDbContextFactory<BondsContext> factory,
            ILogger<MoexBondInfoJob> logger)
        {
            _moexHttpDataClient = moexHttpDataClient;
            _factory = factory;
            _logger = logger;
        }

        public async Task Execute()
        {
            try
            {
                _logger.LogInformation("Собираем идентификаторы эмитентов: {Date}", DateTime.UtcNow);

                await using var context = await _factory.CreateDbContextAsync();

                var dbBonds = await context.BondsMarketdata
                    .Select(x => x.ISIN)
                    .AsNoTracking()
                    .ToListAsync();

                var extendedBonds = await context.BondsExtended
                    .Select(x => x.ISIN)
                    .AsNoTracking()
                    .ToListAsync();

                _logger.LogInformation("Количество бумаг: {Count}", dbBonds.Count);

                var isinForRequest = dbBonds.Except(extendedBonds);
                var bondInfoTasks = isinForRequest.Select(_moexHttpDataClient.GetBondExtendedData).ToArray();
                var bondsInfo = (await Task.WhenAll(bondInfoTasks))
                    .Where(x => x.EmitterId != null)
                    .ToDictionary(x => x.ISIN);

                _logger.LogInformation("Нашли идентификаторы для {Count} бумаг", bondsInfo.Count);

                await context.AddRangeAsync(bondsInfo.Select(x => new BondExtendedEntity
                {
                    UpdatedDate = DateTime.UtcNow,
                    ISIN = x.Key,
                    EmitterId = x.Value.EmitterId,
                    Name = x.Value.Name,
                    ShortName = x.Value.ShortName

                }));
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
        }
    }
}
