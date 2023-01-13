using FridgesData.Entities;

namespace FridgesData.Interfaces
{
    public interface IFridgeRepository
    {
        Task<PagedList<FridgeEntity>> GetAsync(Guid accountId, FridgeParameters fridgeParameters);
        Task<Guid> AddAsync(FridgeEntity fridge);
        Task<FridgeEntity> GetById(Guid id);
        Task DeleteAsync(FridgeEntity entity);
    }
}
