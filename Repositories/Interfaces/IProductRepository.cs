using ASP.NET__web_API_Project.Models;

namespace ASP.NET__web_API_Project.Repositories.Interfaces
{
    public interface IProductRepository
    {
        //C.R.U.D
        //Creat
        Task CreateProduct(Product product);
        Task CreateProduct(string NameOfProduct,string ProductDescription,decimal Price,Category Category);

        //Read
        Task<Product> GetProductById(int ProductId);
        Task<Product> GetProductByName(string ProductName);
        Task<Product> GetProductsByCategory(Category category);

        //Update
        Task UpdateProduct(Product product);    

        //Delete
        Task DeleteProductByName(string ProductName);
        Task DeleteProductByID(int ProductId);
    }
}
