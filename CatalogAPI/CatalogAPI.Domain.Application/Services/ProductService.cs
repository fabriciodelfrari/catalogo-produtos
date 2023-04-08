using AutoMapper;
using CatalogAPI.Domain.Application.DTOs;
using CatalogAPI.Domain.Application.Interfaces;
using CatalogAPI.Domain.Interfaces;
using CatalogAPI.Domain.Model.Entities;

namespace CatalogAPI.Domain.Application.Services
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

        public async Task AddAsync(ProductDTO productDTO)
        {
            var product = _mapper.Map<Product>(productDTO);
            await _productRepository.CreateAsync(product);
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var products = await _productRepository.GetProductsAsync();

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task RemoveAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            await _productRepository.RemoveAsync(product);

        }

        public async Task<ProductDTO> UpdateAsync(ProductDTO productDTO)
        {
            var product = await _productRepository.UpdateAsync(_mapper.Map<Product>(productDTO));

            return _mapper.Map<ProductDTO>(product);
        }
    }
}
