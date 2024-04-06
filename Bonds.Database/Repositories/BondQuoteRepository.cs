using Bonds.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bonds.Database.Repositories
{
    public class BondQuoteRepository : IBondQuoteRepository
    {
        private readonly BondsContext _context;

        public BondQuoteRepository(BondsContext context)
        {
            _context = context;
        }

        public async Task Add(BondQuoteEntity entity)
        {
            await _context.BondQuotes.AddAsync(entity);
        }

        public async Task Add(List<BondQuoteEntity> entity)
        {
            await _context.BondQuotes.AddRangeAsync(entity);
        }

        public async Task<List<BondQuoteEntity>> Get()
        {
            return await _context.BondQuotes.ToListAsync();
        }

        public async Task<List<BondQuoteEntity>> GetByPeriod(DateTime from, DateTime to)
        {
            return null;//await _context.BondQuotes.Where(x => x.SettleDate).ToListAsync();
        }
    }

    public interface IBondQuoteRepository
    {
        Task<List<BondQuoteEntity>> Get();
        Task Add(List<BondQuoteEntity> entity);
        Task Add(BondQuoteEntity entity);
    }
}
