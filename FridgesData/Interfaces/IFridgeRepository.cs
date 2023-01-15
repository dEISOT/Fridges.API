using FridgesData.Entities;

namespace FridgesData.Interfaces
{
    public interface IFridgeRepository
    {
        Task<IEnumerable<FridgeEntity>> GetEnumAsync(Guid userId, FridgeParameters fridgeParameters);
        Task<PagedList<FridgeEntity>> GetAsync(Guid userId, FridgeParameters fridgeParameters);
        Task<Guid> AddAsync(FridgeEntity fridge);
        Task<FridgeEntity> GetById(Guid id);
        Task DeleteAsync(FridgeEntity entity);
        int GetAmount(Guid userId);
    }
}
