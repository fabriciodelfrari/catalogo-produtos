using CatalogAPI.Domain.Application.DTOs;
using CatalogAPI.Domain.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetProductsAsync();

                return Ok(products);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetProductById/{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            try
            {
                var product = await _productService.GetByIdAsync(id);

                return product;
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("RegisterProduct")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> RegisterProduct(ProductDTO productDTO)
        {
            try
            {
                await _productService.AddAsync(productDTO);

                return Ok("Product registered.");

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateProduct")]
        public async Task<ActionResult<ProductDTO>> UpdateProduct(ProductDTO productDTO)
        {
            try
            {
                return await _productService.UpdateAsync(productDTO);
            }
            catch(Exception ex)
            {
                return BadRequest($"{ex.Message}: {ex.InnerException!.Message}");
            }
        }
    }
}
