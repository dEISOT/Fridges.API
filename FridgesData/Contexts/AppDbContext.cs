using FridgesData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgesData.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<FridgeTypeEntity>()
                .HasMany(t => t.Fridges)
                .WithOne(f => f.FridgeType)
                .OnDelete(DeleteBehavior.SetNull);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               .UseLazyLoadingProxies();
        }
        DbSet<FridgeEntity> Fridges { get; set; }
        DbSet<ProductEntity> Products { get; set; }
        DbSet<FridgeTypeEntity> FridgeTypes { get; set; }
        DbSet<FridgeProductEntity> FridgesProducts { get; set; }

    }
}
