﻿using FridgesData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgesData.Interfaces
{
    public interface IFridgeProductRepository
    {
        Task<IEnumerable<FridgeProductEntity>> GetProducts(Guid fridgeId);
        Task<FridgeProductEntity> Update(Guid id, int newQuantity);
    }
}