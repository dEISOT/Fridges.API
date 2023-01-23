using FridgesData.Entities;
using FridgesModel.Request;

namespace FridgesCore.Interfaces
{
    public interface IFridgeTypeService
    {
        Task<IEnumerable<FridgeTypeEntity>> GetAllAsync();
        Task<Guid> AddAsync(FridgeTypeRequest entity);

    }
}
