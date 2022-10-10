using FridgesCore.Domain;
using FridgesData.Entities;

namespace FridgesCore.Interfaces
{
    public interface IFridgeService
    {
        Task<IEnumerable<FridgeEntity>> GetAsync(string accessToken);
        Task<Guid> AddAsync(Fridge fridge, string accessToken);
        Task DeleteAsync(Guid id);
    }
}
