using CatalogAPI.Domain.Interfaces;
using CatalogAPI.Domain.Model.Entities;
using CatalogAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) 
        {
            _db = db;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            _db.Categories.Add(category);
            await _db.SaveChangesAsync();

            return category;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _db.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category> RemoveAsync(Category category)
        {
            _db.Categories.Remove(category);
            await _db.SaveChangesAsync();

            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            _db.Categories.Update(category);
            await _db.SaveChangesAsync();

            return category;
        }
    }
}
