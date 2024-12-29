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

        public async Task<IActionResult> Create()
        {

            return View();
        }
    }


}
