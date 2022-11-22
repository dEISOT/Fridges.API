using FridgesData.Entities;
using FridgesModel.Request;
using FridgesModel.Response;

namespace FridgesCore.Interfaces
{
    public interface IAssortmentService
    {
        Task<IEnumerable<AssortmentResponse>> GetAsync(Guid fridgeId);
        Task<Guid> AddAsync(AssortmentPutRequest AssortmentPutRequest);
        Task<AssortmentEntity> UpdateAsync(Guid assortmentId, int newQuantity);
        Task DeleteAsync(Guid assortmentId);
        Task DeleteAllAsync(Guid fridgeId);
        Task FillingByDefault();
    }
}
