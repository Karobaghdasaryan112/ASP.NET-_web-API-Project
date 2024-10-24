using ASP.NET__web_API_Project.Models;
using ASP.NET__web_API_Project.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET__web_API_Project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private ProductService _productService;
        private ILogger<ProductController> _logger;
        public ProductController(ProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        [HttpPost]
        [Route("CreateProductFromBody")]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            await _productService.CreateProduct(product);
            return Ok();
        }

        [HttpPost]
        [Route("CreateProductFromParams")]
        public async Task<IActionResult> CreateProduct(string nameOfProduct, string productDescription, decimal price, Category category)
        {
            try
            {
                await _productService.CreateProduct(nameOfProduct, productDescription, price, category);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetProductById")]
        public async Task<Product> GetProductById(int ProductId)
        {
            return await _productService.GetProductById(ProductId);
        }
        [HttpGet]
        [Route("GetProductByName")]
        public async Task<Product> GetProductByName(string ProductName)
        {
            try
            {
                var Result = await _productService.GetProductByName(ProductName);
                return Result;
            }
            catch (Exception Ex)
            {
                _logger?.LogError(Ex.Message);
                throw new ArgumentException(nameof(ProductName), Ex);
            }
        }
        [HttpGet]
        [Route("GetProductByCategory")]
        public async Task<Product> GetProductByCategory(Category category)
        {
            try
            {
                var Product = await _productService.GetProductsByCategory(category);
                return Product;
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.Message);
                throw new ArgumentException(nameof(Category), ex);
            }
        }
        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            try
            {
                await _productService.UpdateProduct(product);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ArgumentException($"{ex.Message}", ex);
            }


        }
        [HttpDelete]
        [Route("DeleteProductByName")]
        public async Task<IActionResult> DeleteProductByName(string Name)
        {
            try
            {
                await _productService.DeleteProductByName(Name);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.Message);
                throw new ArgumentException(nameof(Name), ex);
            }
        }
        [HttpDelete]
        [Route("DeleteProductById")]
        public async Task<IActionResult> DeleteProductById(int ProductId)
        {
            try
            {
                await _productService.DeleteProductByID(ProductId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.Message);
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
