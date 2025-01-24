using Essence.Business.Services.Abstractions;
using Essence.Business.UIServices.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Essence.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IHomeService _homeService;

        public HomeController(IProductService productService, IHomeService homeService)
        {
            _productService = productService;
            _homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            var homeDto = await _homeService.GetHomeDtoAsync(); 
            return View(homeDto); 
        }

        public async Task<IActionResult> ProductView()
        {
            var homeDto = await _homeService.GetHomeDtoAsync();
            return View(homeDto);
        }
    }
}
