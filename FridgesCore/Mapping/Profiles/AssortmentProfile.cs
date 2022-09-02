using AutoMapper;
using FridgesCore.Domain;
using FridgesData.Entities;
using FridgesModel.Request;

namespace FridgesCore.Mapping.Profiles
{
    public class AssortmentProfile : Profile
    {
        public AssortmentProfile()
        {
            CreateMap<AssortmentPutRequest, Assortment>();
            CreateMap<AssortmentPutRequest, AssortmentEntity>();
            CreateMap<Assortment, AssortmentEntity>();

        }
    }
}
