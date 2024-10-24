using ASP.NET__web_API_Project.Models;
using ASP.NET__web_API_Project.Repositories.Interfaces;
using ASP.NET_web_API_Project.Data;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET__web_API_Project.Repositories.implementations
{
    public class ProductRepository : IProductRepository
    {
        private AppDbContext _context { get; set; }
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
            
        public async Task CreateProduct(Product product)
        {
            Product product1 = await _context.Products.FirstOrDefaultAsync(Product => Product.ProductId == product.ProductId);
            if (product1 == null)
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
            } throw new ArgumentNullException(nameof(product1));
        }

        public async Task CreateProduct(string NameOfProduct, string ProductDescription, decimal Price, Category Category)
        {
            Product product1 = await _context.Products.FirstOrDefaultAsync(Product => Product.Name == NameOfProduct);
            if (product1 == null)
            {
                Product product = new Product()
                {
                    Name = NameOfProduct,
                    Price = Price,
                    Description = ProductDescription
                };
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();
            }
            throw new ArgumentNullException();
        }

        public async Task<Product> GetProductById(int ProductId)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(Product => Product.ProductId == ProductId);
            if (product != null)
                return product;
            throw new ArgumentNullException();    
        }

        public async Task<Product> GetProductByName(string ProductName)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(Product => Product.Name == ProductName);
            if (product != null)
                return product;
            throw new ArgumentNullException();
        }

        public async Task<Product> GetProductsByCategory(Category category)
        {
            Product product = await _context.Products.FirstOrDefaultAsync(Product => Product.CategoryId == category.CategoryId);
            if (product != null)
                return product;
            throw new ArgumentNullException();
        }

        public async Task UpdateProduct(Product product)
        {
            Product ProductFind = await _context.Products.FirstOrDefaultAsync(Product => Product.ProductId == product.ProductId);
            if (ProductFind != null)
            {
                ProductFind.Price = product.Price;
                ProductFind.Description = product.Description;
                ProductFind.Name = product.Name;    
                await _context.SaveChangesAsync();
            }
            throw new ArgumentNullException();
        }

        public async Task DeleteProductByName(string ProductName)
        {
            Product ProductFind = await _context.Products.FirstOrDefaultAsync(Product => Product.Name == ProductName);
            if (ProductFind != null)
            {
                _context.Products.Remove(ProductFind);
                await _context.SaveChangesAsync();
            }
            throw new ArgumentNullException();
        }

        public async Task DeleteProductByID(int ProductId)
        {
            Product ProductFind = await _context.Products.FirstOrDefaultAsync(Product => Product.ProductId == ProductId);
            if (ProductFind != null)
            {
                _context.Products.Remove(ProductFind);
                await _context.SaveChangesAsync();
            }
            throw new ArgumentNullException();
        }
    }
}
