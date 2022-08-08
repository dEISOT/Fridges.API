using AutoMapper;
using FridgesCore.Domain;
using FridgesData.Entities;
using FridgesModel.Request;
using FridgesModel.Response;

namespace FridgesCore.Mapping.Profiles
{
    public class AuthenticationProfile : Profile
    {
        public AuthenticationProfile()
        {
            CreateMap<AccountEntity, AuthenticateResponse>();
            CreateMap<RegisterRequest, AccountEntity>();
        }
    }
}
