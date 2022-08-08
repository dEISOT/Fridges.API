using FridgesCore.Domain;
using FridgesData.Entities;

namespace FridgesCore.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductEntity>> GetAsync();
        Task<ProductEntity> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(Product product);
    }
}
