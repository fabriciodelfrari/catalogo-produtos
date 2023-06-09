﻿using CatalogAPI.Domain.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogAPI.Domain.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetCategoriesAsync();
        Task<CategoryDTO> GetByIdAsync(int id);
        Task AddAsync(CategoryDTO categoryDto);
        Task UpdateAsync(CategoryDTO categoryDto);
        Task RemoveAsync(int id);

    }
}
