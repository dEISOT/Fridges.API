using FridgesData.Entities;

namespace FridgesData.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetAsync();
        Task<ProductEntity> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(ProductEntity entity);
    }
}
