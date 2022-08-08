using FridgesData.Contexts;
using FridgesData.Entities;
using FridgesData.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FridgesData.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _db;

        public ProductRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Guid> AddAsync(ProductEntity entity)
        {
            _db.Products.Add(entity);
            await _db.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<IEnumerable<ProductEntity>> GetAsync()
        {
            var products = await _db.Products.ToListAsync();
            return products;
        }

        public async Task<ProductEntity> GetByIdAsync(Guid id)
        {
            var product = await _db.Products.FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }
    }
}
