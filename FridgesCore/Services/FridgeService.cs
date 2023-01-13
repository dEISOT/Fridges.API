using AutoMapper;
using FridgesCore.Domain;
using FridgesCore.Interfaces;
using FridgesData.Entities;
using FridgesData.Interfaces;
using FridgesModel.Response;
using System.Security.Claims;

namespace FridgesCore.Services
{
    public class FridgeService : IFridgeService
    {
        private readonly IFridgeRepository _fridgeRepository;
        private readonly IFridgeTypeRepository _typeRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public FridgeService(IFridgeRepository fridgeRepository, ITokenService tokenService, IMapper mapper, IFridgeTypeRepository typeRepository)
        {
            _fridgeRepository = fridgeRepository;
            _tokenService = tokenService;
            _mapper = mapper;
            _typeRepository = typeRepository;  
        }

        public async Task<Guid> AddAsync(Fridge fridge, Guid accountId)
        { 
            fridge.AccountId = accountId;

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

        public async Task<FridgesWithTypes> GetAsync(string id, FridgeParameters fridgeParameters)
        {
            Guid userId = new Guid(id);
            var entities = await _fridgeRepository.GetAsync(userId, fridgeParameters);
            List<FridgeResponse> list = new List<FridgeResponse>();
            foreach (var entity in entities)
            {
                FridgeResponse item = new FridgeResponse()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    AccountName = entity.Account.Email,
                    Type = entity.FridgeType.Name
                };
                list.Add(item);
            }

            var fridges = PagedList<FridgeResponse>.ToPagedList(list, fridgeParameters.PageNumber, fridgeParameters.PageSize);

            //eastern egg
            FridgesWithTypes result = new FridgesWithTypes()
            {
                //Fridges = fridges,
                Types = await _typeRepository.GetAllAsync()
            };

            return result;
        }

    }
}
