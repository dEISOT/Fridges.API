using FridgesCore.Domain;
using FridgesData.Entities;

namespace FridgesCore.Interfaces
{
    public interface IFridgeService
    {
        Task<IEnumerable<FridgeEntity>> GetAsync();
        Task<Guid> AddAsync(Fridge fridge);
        Task DeleteAsync(Guid id);
    }
}
