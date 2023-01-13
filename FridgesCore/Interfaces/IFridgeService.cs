using FridgesCore.Domain;
using FridgesData.Entities;

namespace FridgesCore.Interfaces
{
    public interface IFridgeService
    {
        Task<FridgesWithTypes> GetAsync(string userId, FridgeParameters fridgeParameters);
        Task<Guid> AddAsync(Fridge fridge, Guid accountId);
        Task DeleteAsync(Guid id);
    }
}
