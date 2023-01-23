using AutoMapper;
using FridgesCore.Interfaces;
using FridgesData.Entities;
using FridgesData.Interfaces;
using FridgesModel.Request;

namespace FridgesCore.Services
{
    public class FridgeTypeService : IFridgeTypeService
    {
        private readonly IFridgeTypeRepository _fridgeTypeRepository;
        private readonly IMapper _mapper;

        public FridgeTypeService(IFridgeTypeRepository fridgeTypeRepository, IMapper mapper)
        {
            _fridgeTypeRepository = fridgeTypeRepository;
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(FridgeTypeRequest model)
        {
            var entity = _mapper.Map<FridgeTypeEntity>(model);
            var result = await _fridgeTypeRepository.AddAsync(entity);
            return result;
        }

        public async Task<IEnumerable<FridgeTypeEntity>> GetAllAsync()
        {
            var result = await _fridgeTypeRepository.GetAllAsync();
            return result;
        }
    }
}
