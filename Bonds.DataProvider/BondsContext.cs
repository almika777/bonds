﻿using Bonds.DataProvider.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bonds.DataProvider
{
    public class BondsContext : DbContext
    {
        public DbSet<BondSecurityEntity> BondsSecurities { get; set; }
        public DbSet<BondsMarketdataEntity> BondsMarketdata { get; set; }
        public DbSet<BondExtendedEntity> BondsExtended { get; set; }

        public BondsContext(DbContextOptions<BondsContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


        }
    }
}
