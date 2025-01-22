using Microsoft.AspNetCore.Mvc;

namespace Essence.Presentation.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
