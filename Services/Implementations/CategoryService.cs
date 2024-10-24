using ASP.NET__web_API_Project.Models;
using ASP.NET__web_API_Project.Repositories.implementations;
using ASP.NET__web_API_Project.Services.Interfaces;
using ASP.NET_web_API_Project.Data;

namespace ASP.NET__web_API_Project.Services.Implementations
{
    public class CategoryService : ICategoryService
    {

        private CategoryRepository _categoryRepository { get; set; }
        public CategoryService(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task CreateCategoryByName(string CategoryName)
        {
            await _categoryRepository.CreateCategoryByName(CategoryName);
        }

        public async Task<Category> GetCategoryById(int CategoryId)
        {
            return await _categoryRepository.GetCategoryById(CategoryId);
        }

        public async Task<Category> GetCategoryByName(string CategoryName)
        {
            return await _categoryRepository.GetCategoryByName(CategoryName);
        }

        public async Task UpdateCategoryName(string CategoryName, Category category)
        {
            await _categoryRepository.UpdateCategoryName(CategoryName, category);
        }

        public async Task DeleteCategoryByName(string CategoryName)
        {
            await _categoryRepository.DeleteCategoryByName(CategoryName);
        }

        public async Task DeleteCategoryByID(int CategoryId)
        {
            await _categoryRepository.DeleteCategoryByID(CategoryId);
        }
    }
}
