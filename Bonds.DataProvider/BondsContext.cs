using Bonds.DataProvider.Entities;
using Innofactor.EfCoreJsonValueConverter;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite.Infrastructure.Internal;

namespace Bonds.DataProvider
{
    public class BondsContext : DbContext
    {
        public DbSet<BondEntity> Bonds { get; set; }
        public DbSet<TelegramUserEntity> Users { get; set; }

        public string DbPath { get; }

        public BondsContext(DbContextOptions<BondsContext> options) : base(options)
        {
            DbPath = options.GetExtension<SqliteOptionsExtension>().ConnectionString;
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TelegramUserEntity>(x =>
            {
                x.Property(z => z.BondCriteria).HasJsonValueConversion();
                x.HasIndex(z => z.TelegramId).IsUnique();
            });

        }
    }
}
