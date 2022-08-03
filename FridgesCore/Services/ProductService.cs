using AutoMapper;
using FridgesCore.Domain;
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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;


        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Guid> AddAsync(Product product)
        {
            var entity = _mapper.Map<ProductEntity>(product);
            var id = await _productRepository.AddAsync(entity);
            return id;
        }

        public async Task<IEnumerable<ProductEntity>> GetAsync()
        {
            var products = await _productRepository.GetAsync();
            return products;
        }

        public async Task<ProductEntity> GetByIdAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return product;
        }
    }
}
