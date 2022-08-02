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

        public async Task<IEnumerable<FridgeProductEntity>> GetProducts(Guid fridgeId)
        {
            var products = await _db.FridgesProducts.Where(p => p.FridgeId == fridgeId).ToListAsync();
            return products;
        }

        public async Task<FridgeProductEntity> Update(Guid id, int newQuantity)
        {
            var result = await _db.FridgesProducts.FirstOrDefaultAsync(fp => fp.Id == id);
            result.Quantity = newQuantity;
            await _db.SaveChangesAsync();
            return result;
        }
    }
}
