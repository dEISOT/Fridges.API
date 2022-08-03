using FridgesData.Contexts;
using FridgesData.Entities;
using FridgesData.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgesData.Repositories
{
    public class FridgeProductRepository : IFridgeProductRepository
    {
        private readonly AppDbContext _db;
        public FridgeProductRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<FridgeProductEntity>> GetProductsAsync(Guid fridgeId)
        {
            var products = await _db.FridgesProducts.Where(p => p.FridgeId == fridgeId).ToListAsync();
            return products;
        }

        public async Task<FridgeProductEntity> UpdateAsync(Guid assortmentId, int newQuantity)
        {
            var result = await _db.FridgesProducts.FirstOrDefaultAsync(fp => fp.Id == assortmentId);
            result.Quantity = newQuantity;
            await _db.SaveChangesAsync();
            return result;
        }
        public async Task DeleteAsync(Guid assortmentId)
        {
            var assortment = await _db.FridgesProducts.FirstOrDefaultAsync(fp => fp.Id == assortmentId);
            _db.FridgesProducts.Remove(assortment);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAllAsync(Guid fridgeId)
        {
            var list = await _db.FridgesProducts.Where(fp => fp.FridgeId == fridgeId).ToListAsync();
            foreach(var item in list)
            {
                _db.FridgesProducts.Remove(item);
            }
            await _db.SaveChangesAsync();

        }

        public async Task<FridgeProductEntity> AddAsync(FridgeProductEntity entity)
        {
            await _db.FridgesProducts.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
