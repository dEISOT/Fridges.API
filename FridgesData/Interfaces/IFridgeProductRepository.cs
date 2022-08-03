using FridgesData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgesData.Interfaces
{
    public interface IFridgeProductRepository
    {
        Task<IEnumerable<FridgeProductEntity>> GetProductsAsync(Guid fridgeId);
        Task<FridgeProductEntity> AddAsync(FridgeProductEntity entity);
        Task<FridgeProductEntity> UpdateAsync(Guid assortmentId, int newQuantity);
        Task DeleteAsync(Guid assortmentId);
        Task DeleteAllAsync(Guid fridgeId);

    }
}
