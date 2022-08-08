using AutoMapper;
using FridgesCore.Domain;
using FridgesData.Entities;
using FridgesModel.Request;

namespace FridgesCore.Mapping.Profiles
{
    public class FridgeProductProfile : Profile
    {
        public FridgeProductProfile()
        {
            CreateMap<AssortmentPutRequest, Assortment>();
            CreateMap<AssortmentPutRequest, FridgeProductEntity>();
            CreateMap<Assortment, FridgeProductEntity>();

        }
    }
}
