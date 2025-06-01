using Contracts;
using DTOs.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IServiceManager _manager;
        public CategoryController(IServiceManager manager)
        {
            _manager = manager;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _manager.CategoryService.GetAllCategoriesAsync();
            return View(categories);
        }
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryForCreationDto categoryDto)
        {
            var result = await _manager.CategoryService.AddCategoryAsync(categoryDto);
            if (result.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index));
            return View(categoryDto);
        }
        [HttpGet]
        public async Task<IActionResult> EditCategory([FromRoute]int Id)
        {
            var category=await _manager.CategoryService.GetCategoryAsync(Id);
            var categoryDto = new CategoryForUpdateDto
            {
                CategoryId=category.CategoryId,
                CategoryName=category.CategoryName,
            };
            return View(categoryDto);
        }
        [HttpPost]
        public async Task<IActionResult> EditCategory(CategoryForUpdateDto categoryDto)
        {
            var result = await _manager.CategoryService.EditCategoryAsync(categoryDto);
            if (!result.IsSuccessStatusCode)
                return View(categoryDto);
            return RedirectToAction($"{nameof(Index)}");
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _manager.CategoryService.DeleteCategoryAsync(id);
            return result.IsSuccessStatusCode ?
                Json(new { success = true })
                : Json(new { success = false });
        }
    }
}
