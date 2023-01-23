using FridgesData.Contexts;
using FridgesData.Entities;
using FridgesData.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FridgesData.Repositories
{
    public class FridgeTypeRepository : IFridgeTypeRepository
    {
        private readonly AppDbContext _db;

        public FridgeTypeRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Guid> AddAsync(FridgeTypeEntity entity)
        {
            _db.Add(entity);
            await _db.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<IEnumerable<FridgeTypeEntity>> GetAllAsync()
        {
            var result = await _db.FridgeTypes.ToListAsync();
            return result;
        }
    }
}
