using FridgesCore.Domain;
using FridgesData.Entities;
using FridgesModel.Response;

namespace FridgesCore.Interfaces
{
    public interface IFridgeService
    {
        Task<IEnumerable<FridgeResponse>> GetAsync(string accessToken);
        Task<Guid> AddAsync(Fridge fridge, string accessToken);
        Task DeleteAsync(Guid id);
    }
}
