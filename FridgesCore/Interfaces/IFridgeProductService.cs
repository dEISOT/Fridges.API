using FridgesCore.Domain;
using FridgesData.Entities;
using FridgesModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgesCore.Interfaces
{
    public interface IFridgeProductService
    {
        Task<IEnumerable<FridgeProductEntity>> GetProductsAsync(Guid fridgeId);
        Task<Guid> AddAsync(AssortmentPutRequest AssortmentPutRequest);
        Task<FridgeProductEntity> UpdateAsync(Guid assortmentId, int newQuantity);
        Task DeleteAsync(Guid assortmentId);
        Task DeleteAllAsync(Guid fridgeId);

    }
}
