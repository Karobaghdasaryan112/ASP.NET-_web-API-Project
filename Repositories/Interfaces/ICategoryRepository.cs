using ASP.NET__web_API_Project.Models;

namespace ASP.NET__web_API_Project.Repositories.Interfaces
{
    public interface ICategoryRepository
    {       
        //C.R.U.D
        //Creat
        Task  CreateCategoryByName(string CategoryName);

        //Read
        Task<Category> GetCategoryById(int CategoryId);
        Task<Category> GetCategoryByName(string CategoryName);

        //Update
        Task UpdateCategoryName(string CategoryName,Category category);

        //Delete
        Task DeleteCategoryByName(string CategoryName);
        Task DeleteCategoryByID(int CategoryId);
    }
}
