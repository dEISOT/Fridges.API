using AutoMapper;
using FridgesCore.Domain;
using FridgesData.Entities;
using FridgesModel.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
