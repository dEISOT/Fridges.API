using AutoMapper;
using FridgesCore.Interfaces;
using FridgesData.Entities;
using FridgesData.Interfaces;
using FridgesModel.Request;

namespace FridgesCore.Services
{
    public class AssortmentService : IAssortmentService
    {
        private readonly IAssortmentRepository _assortmentRepository;
        private readonly IMapper _mapper;

        public AssortmentService(IAssortmentRepository frideProductRepository, IMapper mapper)
        {
            _assortmentRepository = frideProductRepository;
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(AssortmentPutRequest assortment)
        {
            var entity = _mapper.Map<AssortmentEntity>(assortment);
            var result = await _assortmentRepository.AddAsync(entity);
            return result.Id;
        }

        public async Task DeleteAsync(Guid assortmentId)
        {
            await _assortmentRepository.DeleteAsync(assortmentId);
        }

        public async Task DeleteAllAsync(Guid fridgeId)
        {
            await _assortmentRepository.DeleteAllAsync(fridgeId);
        }
        /*
         
        */
        public async Task<IEnumerable<AssortmentEntity>> GetProductsAsync(Guid fridgeId)
        {
            var products = await _assortmentRepository.GetProductsAsync(fridgeId);
            return products;
        }
        public async Task<AssortmentEntity> UpdateAsync(Guid assortmentId, int newQuantity)
        {
            var result = await _assortmentRepository.UpdateAsync(assortmentId, newQuantity);
            return result;
        }

        public async Task FillingByDefault()
        {
            await _assortmentRepository.FillingByDefault();

        }
    }
}