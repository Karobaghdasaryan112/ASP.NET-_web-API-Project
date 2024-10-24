using ASP.NET__web_API_Project.Models;
using ASP.NET__web_API_Project.Repositories.implementations;
using ASP.NET__web_API_Project.Services.Interfaces;
using ASP.NET_web_API_Project.Data;

namespace ASP.NET__web_API_Project.Services.Implementations
{
    public class ProductService : IProductService
    {

        private ProductRepository _productRepository;
        public ProductService(ProductRepository productRepository)
        {

            _productRepository = productRepository;
        }

        public async Task CreateProduct(Product product)
        {
           await _productRepository.CreateProduct(product);
        }

        public async Task CreateProduct(string NameOfProduct, string ProductDescription, decimal Price, Category Category)
        {
            await _productRepository.CreateProduct(NameOfProduct, ProductDescription, Price, Category);
        }

        public async Task DeleteProductByID(int ProductId)
        {
            await _productRepository.DeleteProductByID(ProductId);
        }

        public async Task DeleteProductByName(string ProductName)
        {
            await _productRepository.DeleteProductByName(ProductName);
        }

        public async Task<Product> GetProductById(int ProductId)
        {
            return await _productRepository.GetProductById(ProductId);
        }

        public async Task<Product> GetProductByName(string ProductName)
        {
            return await _productRepository.GetProductByName(ProductName);
        }

        public async Task<Product> GetProductsByCategory(Category category)
        {
            return await _productRepository.GetProductsByCategory(category);
        }

        public async Task UpdateProduct(Product product)
        {
            await _productRepository.UpdateProduct(product);
        }
    }
}
