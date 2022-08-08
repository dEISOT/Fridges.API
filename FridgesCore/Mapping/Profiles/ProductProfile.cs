using AutoMapper;
using FridgesCore.Domain;
using FridgesData.Entities;
using FridgesModel.Request;

namespace FridgesCore.Mapping.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductRequest, Product>();
            CreateMap<Product, ProductEntity>();
        }
    }
}
