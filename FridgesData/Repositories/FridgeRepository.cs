using FridgesData.Contexts;
using FridgesData.Entities;
using FridgesData.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FridgesData.Repositories
{
    public class FridgeRepository : IFridgeRepository
    {
        private readonly AppDbContext _db;

        public FridgeRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Guid> AddAsync(FridgeEntity fridge)
        {
            _db.Fridges.Add(fridge);
            await _db.SaveChangesAsync();
            return fridge.Id; 
        }

        public async Task DeleteAsync(FridgeEntity entity)
        {
            _db.Fridges.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<FridgeEntity>> GetAsync(Guid accountId)
        {
            var result = await _db.Fridges.Where(f => f.AccountId == accountId).ToListAsync();
            return result;
        }

        public async Task<FridgeEntity> GetById(Guid id)
        {
            var result = await _db.Fridges.FirstOrDefaultAsync(f => f.Id == id);
            return result;
        }
    }
}
