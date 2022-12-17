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
            CreateMap<AssortmentPostRequest, Assortment>();
            CreateMap<AssortmentPostRequest, AssortmentEntity>();
            CreateMap<Assortment, AssortmentEntity>();

        }
    }
}
