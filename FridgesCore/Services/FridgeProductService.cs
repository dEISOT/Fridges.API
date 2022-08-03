using AutoMapper;
using FridgesCore.Domain;
using FridgesCore.Interfaces;
using FridgesData.Entities;
using FridgesData.Interfaces;
using FridgesModel.Request;
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
        private readonly IMapper _mapper;

        public FridgeProductService(IFridgeProductRepository frideProductRepository, IMapper mapper)
        {
            _frideProductRepository = frideProductRepository;
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(AssortmentPutRequest assortment)
        {
            var entity = _mapper.Map<FridgeProductEntity>(assortment);
            var result = await _frideProductRepository.AddAsync(entity);
            return result.Id;
        }

        public async Task DeleteAsync(Guid assortmentId)
        {
            await _frideProductRepository.DeleteAsync(assortmentId);
        }

        public async Task DeleteAllAsync(Guid fridgeId)
        {
            await _frideProductRepository.DeleteAllAsync(fridgeId);
        }

        public async Task<IEnumerable<FridgeProductEntity>> GetProductsAsync(Guid fridgeId)
        {
            var products = await _frideProductRepository.GetProductsAsync(fridgeId);
            return products; 
        }
        public async Task<FridgeProductEntity> UpdateAsync(Guid assortmentId, int newQuantity)
        {
            var result = await _frideProductRepository.UpdateAsync(assortmentId, newQuantity);
            return result;
        }

        public async Task FillingByDefault()
        {
            await _frideProductRepository.FillingByDefault();

        }
    }
}
