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

        public async Task<PagedList<FridgeEntity>> GetAsync(Guid userId, FridgeParameters fridgeParameters)
        {
            var result = await PagedList<FridgeEntity>.ToPagedList(_db.Fridges.Where(f => f.AccountId == userId),
                fridgeParameters.PageNumber,
                fridgeParameters.PageSize);

            return result;
        }

        public int GetAmount(Guid userId)
        {
            var result = _db.Fridges.Where(a => a.AccountId == userId).Count();

            return result;
        }
        public async Task<IEnumerable<FridgeEntity>> GetEnumAsync(Guid accountId, FridgeParameters fridgeParameters)
        {
            var result = await  _db.Fridges.Where(f => f.AccountId == accountId)
                .Skip((fridgeParameters.PageNumber - 1) * fridgeParameters.PageSize)
                .Take(fridgeParameters.PageSize)
                .ToListAsync();
             
            return result;
        }

        public async Task<FridgeEntity> GetById(Guid id)
        {
            var result = await _db.Fridges.FirstOrDefaultAsync(f => f.Id == id);
            return result;
        }
    }
}
