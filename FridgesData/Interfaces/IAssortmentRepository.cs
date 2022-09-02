using FridgesData.Entities;

namespace FridgesData.Interfaces
{
    public interface IAssortmentRepository
    {
        Task<IEnumerable<AssortmentEntity>> GetProductsAsync(Guid fridgeId);
        Task<AssortmentEntity> AddAsync(AssortmentEntity entity);
        Task<AssortmentEntity> UpdateAsync(Guid assortmentId, int newQuantity);
        Task DeleteAsync(Guid assortmentId);
        Task DeleteAllAsync(Guid fridgeId);
        Task FillingByDefault();

    }
}
