using AutoMapper;
using FridgesCore.Domain;
using FridgesData.Entities;
using FridgesModel.Request;

namespace FridgesCore.Mapping.Profiles
{
    public class FridgeProfile : Profile
    {
        public FridgeProfile()
        {
            CreateMap<FridgeRequestModel, Fridge>();
            CreateMap<Fridge, FridgeEntity>();
        }
    }
}
