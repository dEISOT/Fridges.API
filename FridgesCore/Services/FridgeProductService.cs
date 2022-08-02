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

        public async Task<Guid> Add(AssortmentPutRequest assortment)
        {
            var entity = _mapper.Map<FridgeProductEntity>(assortment);
            var result = await _frideProductRepository.Add(entity);
            return result.Id;
        }

        public async Task Delete(Guid assortmentId)
        {
            await _frideProductRepository.Delete(assortmentId);
        }

        public async Task DeleteAll(Guid fridgeId)
        {
            await _frideProductRepository.DeleteAll(fridgeId);
        }

        public async Task<IEnumerable<FridgeProductEntity>> GetProducts(Guid fridgeId)
        {
            var products = await _frideProductRepository.GetProducts(fridgeId);
            return products; 
        }
        public async Task<FridgeProductEntity> Update(Guid assortmentId, int newQuantity)
        {
            var result = await _frideProductRepository.Update(assortmentId, newQuantity);
            return result;
        }
    }
}
