using AutoMapper;
using FridgesData.Entities;
using FridgesModel.Request;

namespace FridgesCore.Mapping.Profiles
{
    public class FridgeTypeProfile : Profile
    {
        public FridgeTypeProfile()
        {
            CreateMap<FridgeTypeRequest, FridgeTypeEntity>();
                
        }
        
    }
}
