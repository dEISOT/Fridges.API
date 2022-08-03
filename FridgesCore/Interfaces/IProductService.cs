using FridgesCore.Domain;
using FridgesData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgesCore.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductEntity>> GetAsync();
        Task<ProductEntity> GetByIdAsync(Guid id);
        Task<Guid> AddAsync(Product product);
    }
}
