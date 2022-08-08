using AutoMapper;
using FridgesCore.Domain;
using FridgesCore.Interfaces;
using FridgesData.Entities;
using FridgesData.Interfaces;

namespace FridgesCore.Services
{
    public class FridgeService : IFridgeService
    {
        private readonly IFridgeRepository _fridgeRepository;
        private readonly IMapper _mapper;
        public FridgeService(IFridgeRepository fridgeRepository, IMapper mapper)
        {
            _fridgeRepository = fridgeRepository;
            _mapper = mapper;  
        }

        public async Task<Guid> AddAsync(Fridge fridge)
        {
            var entity = _mapper.Map<FridgeEntity>(fridge);
            var result = await _fridgeRepository.AddAsync(entity);
            return result;
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var fridge = await _fridgeRepository.GetById(id);
                if(fridge is null)
                {

                }
                await _fridgeRepository.DeleteAsync(fridge);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<FridgeEntity>> GetAsync()
        {
            var result = await _fridgeRepository.GetAsync();
            return result;
        }

    }
}
