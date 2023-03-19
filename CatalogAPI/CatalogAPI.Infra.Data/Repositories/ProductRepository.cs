using CatalogAPI.Domain.Entities;
using CatalogAPI.Domain.Interfaces;
using CatalogAPI.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _db.Products.Add(product);
            await _db.SaveChangesAsync();

            return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {

            return await _db.Products.FindAsync(id);

        }

        public async Task<Product> GetProductCategoryAsync(int? id)
        {
            return await _db.Products
                        .Include(p => p.Category)
                        .SingleOrDefaultAsync(p => p.Id == id);

        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _db.Products.Update(product);
            await _db.SaveChangesAsync();

            return product;
        }
    }
}
