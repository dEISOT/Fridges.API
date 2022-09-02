using FridgesData.Entities;

namespace FridgesCore.Interfaces
{
    public interface IFridgeType
    {
        Task<IEnumerable<FridgeTypeEntity>> Get();
        Task<Guid> Add(FridgeTypeEntity entity);

    }
}
