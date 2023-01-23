using FridgesData.Entities;
using System.Collections;

namespace FridgesData.Interfaces
{
    public interface IFridgeTypeRepository
    {
        Task<IEnumerable<FridgeTypeEntity>> GetAllAsync();
        Task<Guid> AddAsync(FridgeTypeEntity entity);
    }
}
