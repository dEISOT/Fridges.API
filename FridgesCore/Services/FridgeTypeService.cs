using FridgesCore.Interfaces;
using FridgesData.Entities;
using FridgesData.Interfaces;

namespace FridgesCore.Services
{
    public class FridgeTypeService : IFridgeTypeService
    {
        private readonly IFridgeTypeRepository _fridgeTypeRepository;

        public FridgeTypeService(IFridgeTypeRepository fridgeTypeRepository)
        {
            _fridgeTypeRepository = fridgeTypeRepository;
        }

        public Task<Guid> Add(FridgeTypeEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FridgeTypeEntity>> Get()
        {
            var result = await _fridgeTypeRepository.GetAllAsync();
            return result;
        }
    }
}
