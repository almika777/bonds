using Bonds.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bonds.Database
{
    public class BondsContext : DbContext
    {
        public BondsContext(DbContextOptions<BondsContext> options) : base(options)
        {
            
        }
        public DbSet<BondQuoteEntity> BondQuotes { get; set; }
        public DbSet<BondTradeEntity> BondTrades { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BondQuoteEntity>().ToTable("BondQuotes");
            modelBuilder.Entity<BondTradeEntity>().ToTable("BondTrades");
        }
    }
}
