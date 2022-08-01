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
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // использование Fluent API
            base.OnModelCreating(modelBuilder);

            //relation between Fridge & FridgeType
            modelBuilder
                .Entity<FridgeTypeEntity>()
                .HasMany(ft => ft.Fridges)
                .WithOne(f => f.FridgeType)
                .HasForeignKey(f => f.TypeId);

            //Relation between Fridge & Product
            modelBuilder.Entity<FridgeProductEntity>()
               .HasKey(fp => new { fp.FridgeId, fp.ProductId });

            modelBuilder.Entity<FridgeProductEntity>()
                .HasOne(fp => fp.Fridge)
                .WithMany(f => f.FridgeProductEntities)
                .HasForeignKey(fp => fp.FridgeId);

            modelBuilder.Entity<FridgeProductEntity>()
                .HasOne(fp => fp.Product)
                .WithMany(p => p.FridgeProductEntities)
                .HasForeignKey(fp => fp.ProductId);

            //seeding
            modelBuilder.Entity<FridgeTypeEntity>().HasData(
                new FridgeTypeEntity[]
                {
                    new FridgeTypeEntity{Id = new Guid("2f48bed2-c5ba-48c9-aca3-1639f75ada10"), Name = "Atlant"}
                });
            
            
        }

        
        public DbSet<FridgeEntity> Fridges { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<FridgeTypeEntity> FridgeTypes { get; set; }
        public DbSet<FridgeProductEntity> FridgesProducts { get; set; }

    }
}
