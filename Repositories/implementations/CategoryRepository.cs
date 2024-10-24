using ASP.NET__web_API_Project.Models;
using ASP.NET__web_API_Project.Repositories.Interfaces;
using ASP.NET_web_API_Project.Data;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET__web_API_Project.Repositories.implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private AppDbContext _context { get; set; }
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateCategoryByName(string CategoryName)
        {
            Category category = await _context.Categories.FirstOrDefaultAsync(category => category.Name == CategoryName);
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> GetCategoryById(int CategoryId)
        {
            Category category = await _context.Categories.FirstOrDefaultAsync(category => category.CategoryId == CategoryId);
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            return category;
        }

        public async Task<Category> GetCategoryByName(string CategoryName)
        {
            Category category = await _context.Categories.FirstOrDefaultAsync(category => category.Name == CategoryName);
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            return category;
        }

        public async Task UpdateCategoryName(string CategoryName, Category category)
        {
            Category category1 = await _context.Categories.FirstOrDefaultAsync(category => category.Name == CategoryName);
            if (category1 == null)
                throw new ArgumentNullException(nameof(category1));
            category1.Name = category.Name;
            category1.Description = category.Description;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryByName(string CategoryName)
        {
            Category category = await _context.Categories.FirstOrDefaultAsync(category => category.Name == CategoryName);
            if (category == null)
                throw new ArgumentNullException(nameof(category));
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryByID(int CategoryId)
        {
            Category category = await _context.Categories.FirstOrDefaultAsync(category => category.CategoryId == CategoryId);
            if (category == null)
                throw new ArgumentNullException($"Category {CategoryId}");
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
