using ASP.NET__web_API_Project.Models;
using ASP.NET__web_API_Project.Services.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET__web_API_Project.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private CategoryService _categoryService;
        private ILogger<CategoryController> _logger;
        public CategoryController(CategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }
        [HttpPost]
        [Route("CreateCategoryByName")]
        public async Task<IActionResult> CreateCategoryByName(string CategoryName)
        {
            try
            {
                await _categoryService.CreateCategoryByName(CategoryName);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetCategoryById")]
        public async Task<Category> GetCategoryById(int CategoryId)
        {
            try
            {
                var Category = await _categoryService.GetCategoryById(CategoryId);
                return Category;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ArgumentNullException(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetCategoryByName")]
        public async Task<Category> GetCategoryByName(string CategoryName)
        {
            try
            {
                var Category = await _categoryService.GetCategoryByName(CategoryName);
                return Category;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new ArgumentNullException($"Category {CategoryName}");
            }
        }
        [HttpPut]
        [Route("UpdateCategoryName")]
        public async Task<IActionResult> UpdateCategoryName(string Name, Category category)
        {
            try
            {
                await _categoryService.UpdateCategoryName(Name, category);
                return Ok(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("DeleteCategoryByName")]
        public async Task<IActionResult> DeleteCategoryByName(string Name)
        {
            try
            {
                await _categoryService.DeleteCategoryByName(Name);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }
        [HttpDelete]
        [Route("DeleteCategoryById")]
        public async Task<IActionResult> DeleteCategoryById(int Id)
        {
            try
            {
                await _categoryService.DeleteCategoryByID(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
