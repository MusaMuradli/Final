using Essence.Business.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Essence.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController:Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategories();
            return Json(categories);
        }
    }
}
