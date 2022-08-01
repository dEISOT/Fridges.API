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
    public class FridgeProfile : Profile
    {
        public FridgeProfile()
        {
            CreateMap<FridgeRequestModel, Fridge>();
            CreateMap<Fridge, FridgeEntity>();
        }
    }
}
