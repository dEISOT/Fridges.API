using FridgesData.Entities;

namespace FridgesCore.Interfaces
{
    public interface IFridgeTypeService
    {
        Task<IEnumerable<FridgeTypeEntity>> Get();
        Task<Guid> Add(FridgeTypeEntity entity);

    }
}
