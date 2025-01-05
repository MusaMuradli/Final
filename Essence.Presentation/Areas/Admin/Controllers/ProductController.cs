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
            var products =  _service.GetAll();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var brands = await _service.GetBrandsAsync(); // Brendləri ProductService vasitəsilə gətiririk
            ViewData["Brands"] = brands; // UI-ya ötürürük
            return View(new ProductCreateDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto dto)
        {
            var result = await _service.CreateAsync(dto, ModelState);

            if (!result)
            {
                ViewData["Brands"] = await _service.GetBrandsAsync();
                dto = await _service.GetCreatedDtoAsync(dto);
                return View(dto);
            }

            return RedirectToAction(nameof(Index));
        }


    }


}
