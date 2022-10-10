using FridgesData.Contexts;
using FridgesData.Entities;
using FridgesData.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FridgesData.Repositories
{
    public class AssortmentRepository : IAssortmentRepository
    {
        private readonly AppDbContext _db;
        public AssortmentRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<AssortmentEntity>> GetAsync(Guid fridgeId)
        {
            var products = await _db.Assortments.Where(p => p.FridgeId == fridgeId).ToListAsync();
            return products;
        }

        public async Task<AssortmentEntity> UpdateAsync(Guid assortmentId, int newQuantity)
        {
            var result = await _db.Assortments.FirstOrDefaultAsync(fp => fp.Id == assortmentId);
            result.Quantity = newQuantity;
            await _db.SaveChangesAsync();
            return result;
        }
        public async Task DeleteAsync(Guid assortmentId)
        {
            var assortment = await _db.Assortments.FirstOrDefaultAsync(fp => fp.Id == assortmentId);
            _db.Assortments.Remove(assortment);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAllAsync(Guid fridgeId)
        {
            var list = await _db.Assortments.Where(fp => fp.FridgeId == fridgeId).ToListAsync();
            foreach(var item in list)
            {
                _db.Assortments.Remove(item);
            }
            await _db.SaveChangesAsync();

        }

        public async Task<AssortmentEntity> AddAsync(AssortmentEntity entity)
        {
            await _db.Assortments.AddAsync(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task FillingByDefault()
        {
            _db.Assortments.FromSqlRaw("spFilling");
            await _db.SaveChangesAsync();
        }
    }
}
