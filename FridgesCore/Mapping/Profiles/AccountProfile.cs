using AutoMapper;
using FridgesData.Entities;
using FridgesModel.Request;

namespace FridgesCore.Mapping.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<RegisterRequest, AccountEntity>();
        }
    }
}
