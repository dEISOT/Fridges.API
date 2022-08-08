using FridgesData.Entities;
using FridgesModel.Request;

namespace FridgesCore.Interfaces
{
    public interface IFridgeProductService
    {
        Task<IEnumerable<FridgeProductEntity>> GetProductsAsync(Guid fridgeId);
        Task<Guid> AddAsync(AssortmentPutRequest AssortmentPutRequest);
        Task<FridgeProductEntity> UpdateAsync(Guid assortmentId, int newQuantity);
        Task DeleteAsync(Guid assortmentId);
        Task DeleteAllAsync(Guid fridgeId);
        Task FillingByDefault();
    }
}
