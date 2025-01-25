using Essence.Business.Dtos.ProductDtos;
using Essence.Business.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Essence.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _service;

        public ProductController(IProductService productService)
        {
            _service = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _service.GetProductsAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var brandAndCategories = await _service.GetBrandAndCategoriesAsync();
            return View(brandAndCategories);
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto dto)
        {
            // Məhsul yaradılması zamanı hər hansı səhv varsa
            var result = await _service.CreateAsync(dto, ModelState);
            if (!result)
            {
                // Brand və Kateqoriya məlumatlarını yenidən yükləyirik, çünki `Create` görünüşü bunları tələb edir
                var brandAndCategories = await _service.GetBrandAndCategoriesAsync();
                return View(brandAndCategories);
            }

            // Məhsul uğurla yaradılıbsa, Index səhifəsinə yönləndir
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Details(int id)
        {
            var product = await _service.GetAsync(id);

            return View(product);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }


}
