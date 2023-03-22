using CatalogAPI.Domain.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogAPI.Domain.Application.Interfaces
{
    public interface IProductService
    {
        Task AddAsync(ProductDTO productDTO);
        Task<ProductDTO> GetByIdAsync(int id);
        Task<IEnumerable<ProductDTO>> GetProductsAsync();
        Task<ProductDTO> UpdateAsync(ProductDTO productDTO);
        Task RemoveAsync(int id);
    }
}
