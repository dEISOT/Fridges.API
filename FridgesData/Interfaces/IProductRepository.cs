using FridgesData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgesData.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetAsync();
        Task<ProductEntity> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(ProductEntity entity);
    }
}
