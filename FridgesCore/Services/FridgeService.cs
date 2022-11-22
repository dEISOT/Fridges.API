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
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public FridgeService(IFridgeRepository fridgeRepository, ITokenService tokenService, IMapper mapper)
        {
            _fridgeRepository = fridgeRepository;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(Fridge fridge, string accessToken)
        {
            var principal = _tokenService.DecodeJwtToken(accessToken);
            var claims = principal.Claims.ToArray();
            Guid id = new Guid(claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            fridge.AccountId = id;

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

        public async Task<IEnumerable<FridgeResponse>> GetAsync(string id)
        {
            //var principal = _tokenService.DecodeJwtToken(accessToken);
            //var claims = principal.Claims.ToArray();
            Guid Id = new Guid(id);
            var entities = await _fridgeRepository.GetAsync(Id);
            List<FridgeResponse> fridges = new List<FridgeResponse>();
            foreach (var entity in entities)
            {
                FridgeResponse item = new FridgeResponse()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    AccountName = entity.Account.Email,
                    Type = entity.FridgeType.Name
                };
                fridges.Add(item);
            }
            return fridges;
        }

    }
}
