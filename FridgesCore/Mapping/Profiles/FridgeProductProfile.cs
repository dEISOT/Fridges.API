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
