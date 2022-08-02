using FridgesCore.Interfaces;
using FridgesData.Entities;
using FridgesData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgesCore.Services
{
    public class FridgeProductService : IFridgeProductService
    {
        private readonly IFridgeProductRepository _frideProductRepository;

        public FridgeProductService(IFridgeProductRepository frideProductRepository)
        {
            _frideProductRepository = frideProductRepository;
        }

        public async Task<IEnumerable<FridgeProductEntity>> GetProducts(Guid fridgeId)
        {
            var products = await _frideProductRepository.GetProducts(fridgeId);
            return products; 
        }
        public async Task<FridgeProductEntity> Update(Guid id, int newQuantity)
        {
            var result = await _frideProductRepository.Update(id, newQuantity);
            return result;
        }
    }
}
