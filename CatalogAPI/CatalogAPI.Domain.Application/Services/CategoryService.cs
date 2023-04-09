using AutoMapper;
using CatalogAPI.Domain.Application.DTOs;
using CatalogAPI.Domain.Application.Interfaces;
using CatalogAPI.Domain.Interfaces;
using CatalogAPI.Domain.Model.Entities;

namespace CatalogAPI.Domain.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task AddAsync(CategoryDTO categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.CreateAsync(category);
        }

        public async Task<CategoryDTO> GetByIdAsync(int id)
        {
            var categorie = await _categoryRepository.GetByIdAsync(id);

            return _mapper.Map<CategoryDTO>(categorie);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesAsync()
        {
            var categories = await _categoryRepository.GetCategoriesAsync();

            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task RemoveAsync(int id)
        {
            var category = _categoryRepository.GetByIdAsync(id).Result;
            await _categoryRepository.RemoveAsync(category);
        }

        public async Task UpdateAsync(CategoryDTO categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
