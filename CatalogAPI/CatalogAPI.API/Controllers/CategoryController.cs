using CatalogAPI.Domain.Application.DTOs;
using CatalogAPI.Domain.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategories()
        {
            try
            {
                var categories = await _categoryService.GetCategoriesAsync();

                return Ok(categories);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
