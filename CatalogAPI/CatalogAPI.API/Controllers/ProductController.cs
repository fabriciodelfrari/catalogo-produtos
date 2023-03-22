using CatalogAPI.Domain.Application.DTOs;
using CatalogAPI.Domain.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
    }
}
