using FridgesData.Entities;

namespace FridgesData.Interfaces
{
    public interface IFridgeRepository
    {
        Task<IEnumerable<FridgeEntity>> GetAsync();
        Task<Guid> AddAsync(FridgeEntity fridge);
        Task<FridgeEntity> GetById(Guid id);
        Task DeleteAsync(FridgeEntity entity);
    }
}
