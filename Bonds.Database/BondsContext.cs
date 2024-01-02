using Bonds.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bonds.Database
{
    public class BondsContext : DbContext
    {
        public BondsContext(DbContextOptions<BondsContext> options) : base(options)
        {
            
        }
        public DbSet<UserEntity> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>().ToTable("Users");
        }
    }
}
