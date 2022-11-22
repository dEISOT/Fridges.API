using AutoMapper;
using FridgesCore.Interfaces;
using FridgesData.Entities;
using FridgesData.Interfaces;
using FridgesModel.Request;
using FridgesModel.Response;

namespace FridgesCore.Services
{
    public class AssortmentService : IAssortmentService
    {
        private readonly IAssortmentRepository _assortmentRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public AssortmentService(IAssortmentRepository assortmentRepository, IProductRepository productRepository, IMapper mapper)
        {
            _assortmentRepository = assortmentRepository;
            _productRepository = productRepository;
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
        public async Task<IEnumerable<AssortmentResponse>> GetAsync(Guid fridgeId)
        {
            var entities = await _assortmentRepository.GetAsync(fridgeId);
            var products = await _productRepository.GetAsync();
            List<AssortmentResponse> result = new List<AssortmentResponse>();
            foreach(var entity in entities)
            {
                AssortmentResponse item = new AssortmentResponse()
                {
                    Id = entity.Id,
                    Name = products.FirstOrDefault(p => p.Id == entity.ProductId).Name,
                    Quantity = entity.Quantity,
                };
                result.Add(item);
            }    
            return result;
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