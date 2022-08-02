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
        Task<IEnumerable<FridgeProductEntity>> GetProducts(Guid fridgeId);
        Task<Guid> Add(AssortmentPutRequest AssortmentPutRequest);
        Task<FridgeProductEntity> Update(Guid assortmentId, int newQuantity);
        Task Delete(Guid assortmentId);
        Task DeleteAll(Guid fridgeId);

    }
}
