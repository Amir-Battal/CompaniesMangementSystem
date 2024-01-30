
using APIs_Task.Dtos.Product;
using APIs_Task.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIs_Task.Controllers
{
    [Route("api/[controller]/[action]")]//todo Route("api/[controller]/[action]") ||DONE||
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _productService.GetAll();

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] AddProductDto dto)
        {
            var product = new Product
            {
                ProductName = dto.ProductName,
                ProductType = dto.ProductType,
            };

            await _productService.Add(product);

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromForm] AddProductDto dto)
        {
            var product = await _productService.GetById(id);

            if (product == null)
                return NotFound($"No product was found with ID: {id}");

            product.ProductName = dto.ProductName;
            product.ProductType = dto.ProductType;

            _productService.Update(product);

            return Ok(product);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var product = await _productService.GetById(id);

            if (product == null)
                return NotFound($"No product was found with ID: {id}");

            _productService.Delete(product);

            return Ok(product);

        }
    }
}
