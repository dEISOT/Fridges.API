﻿using FridgesData.Entities;
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
            modelBuilder
                .Entity<FridgeProductEntity>()
                .HasKey(fp => fp.Id);

            modelBuilder
                .Entity<FridgeProductEntity>()
                .HasIndex(fp => new {fp.ProductId, fp.FridgeId }).IsUnique();



            //relation between Fridge & FridgeType
            modelBuilder
                .Entity<FridgeTypeEntity>()
                .HasMany(ft => ft.Fridges)
                .WithOne(f => f.FridgeType)
                .HasForeignKey(f => f.TypeId);

            //Relation between Fridge & Product

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
                    new FridgeTypeEntity{Id = new Guid("2f48bed2-c5ba-48c9-aca3-1639f75ada10"), Name = "Atlant"},
                    new FridgeTypeEntity{Id = new Guid("a6b022e2-53e0-4dfe-943a-73cb99ebd5ec"), Name = "Minsk"},
                    new FridgeTypeEntity{Id = new Guid("64194695-dce1-4f19-b2ff-0a44a00221bc"), Name = "Samsung"},
                    new FridgeTypeEntity{Id = new Guid("25166c30-161b-4abf-b84a-4f911b3c7e8d"), Name = "LG"},
                    new FridgeTypeEntity{Id = new Guid("af831ce2-35f2-4939-a1ce-2ce872b48393"), Name = "Xiaomi"}
                });
            modelBuilder.Entity<ProductEntity>().HasData(
                new ProductEntity[]
                {
                    new ProductEntity{Id = new Guid("30e16fd7-78d1-4983-92d3-facbda7ea44a"), Name = "Apple", DefaultQuantity = 1},
                    new ProductEntity{Id = new Guid("511b1236-e8b3-4e8f-8a42-90afb933e582"), Name = "Meat"},
                    new ProductEntity{Id = new Guid("a00a8c94-2e88-4d50-9489-eaac087bb8fe"), Name = "Milk"},
                    new ProductEntity{Id = new Guid("44e6123e-61f9-47ef-8ab2-9e1ab272b282"), Name = "Pear"},
                    new ProductEntity{Id = new Guid("d392bcc0-b683-48d4-bcc0-ae8298f66e9b"), Name = "Beer"}

                });

            modelBuilder.Entity<FridgeEntity>().HasData(
                new FridgeEntity[]
                {
                    new FridgeEntity{Id = new Guid("bd38f93f-93b7-4b7c-9b9d-2e6a9e2df441"), Name = "1.1", TypeId = new Guid("2f48bed2-c5ba-48c9-aca3-1639f75ada10") },
                    new FridgeEntity{Id = new Guid("f08d94df-36c1-49cb-a038-2b8249272e6a"), Name = "2.1", TypeId = new Guid("a6b022e2-53e0-4dfe-943a-73cb99ebd5ec") },
                    new FridgeEntity{Id = new Guid("b92bd99d-a6e6-4d4d-9571-c36c479e67e0"), Name = "3.1", TypeId = new Guid("64194695-dce1-4f19-b2ff-0a44a00221bc") },
                    new FridgeEntity{Id = new Guid("9a97645c-1ad6-403e-87eb-bc4fa46a3bce"), Name = "4.1", TypeId = new Guid("25166c30-161b-4abf-b84a-4f911b3c7e8d") },
                    new FridgeEntity{Id = new Guid("39f2a3d3-ef45-470e-b7c4-edd099b21a3b"), Name = "5.1", TypeId = new Guid("af831ce2-35f2-4939-a1ce-2ce872b48393") },
                });

            modelBuilder.Entity<FridgeProductEntity>().HasData(
                new FridgeProductEntity[]
                {
                    new FridgeProductEntity{Id = new Guid("8808abfe-c674-4d19-a520-e821d09967de"), FridgeId = new Guid("bd38f93f-93b7-4b7c-9b9d-2e6a9e2df441"), ProductId = new Guid("44e6123e-61f9-47ef-8ab2-9e1ab272b282"), Quantity = 3},
                    new FridgeProductEntity{Id = new Guid("2cf60975-13d0-480d-a260-ecd5d23e0e64"), FridgeId = new Guid("bd38f93f-93b7-4b7c-9b9d-2e6a9e2df441"), ProductId = new Guid("511B1236-E8B3-4E8F-8A42-90AFB933E582"), Quantity = 7},
                    new FridgeProductEntity{Id = new Guid("b932c22c-a9dc-423a-847b-8aac9289bf4e"), FridgeId = new Guid("bd38f93f-93b7-4b7c-9b9d-2e6a9e2df441"), ProductId = new Guid("D392BCC0-B683-48D4-BCC0-AE8298F66E9B"), Quantity = 36},
                    new FridgeProductEntity{Id = new Guid("7a8ac168-c818-4a61-9cc7-30d8dc467b48"), FridgeId = new Guid("f08d94df-36c1-49cb-a038-2b8249272e6a"), ProductId = new Guid("D392BCC0-B683-48D4-BCC0-AE8298F66E9B"), Quantity = 4},
                    new FridgeProductEntity{Id = new Guid("5f40f47d-cec6-4386-9eff-145aa13e1e9b"), FridgeId = new Guid("f08d94df-36c1-49cb-a038-2b8249272e6a"), ProductId = new Guid("30E16FD7-78D1-4983-92D3-FACBDA7EA44A"), Quantity = 8},
                    new FridgeProductEntity{Id = new Guid("fd36c4b7-2668-4d78-895f-150fc0c83ccc"), FridgeId = new Guid("9a97645c-1ad6-403e-87eb-bc4fa46a3bce"), ProductId = new Guid("511B1236-E8B3-4E8F-8A42-90AFB933E582"), Quantity = 14},
                    new FridgeProductEntity{Id = new Guid("ec9ee5cd-80d5-4ce9-8de5-41b24ecc2e76"), FridgeId = new Guid("9a97645c-1ad6-403e-87eb-bc4fa46a3bce"), ProductId = new Guid("44E6123E-61F9-47EF-8AB2-9E1AB272B282"), Quantity = 2},
                });

        }

        
        public DbSet<FridgeEntity> Fridges { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<FridgeTypeEntity> FridgeTypes { get; set; }
        public DbSet<FridgeProductEntity> FridgesProducts { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<UserCredentialsEntity> UserCredentials { get; set; }

    }
}
