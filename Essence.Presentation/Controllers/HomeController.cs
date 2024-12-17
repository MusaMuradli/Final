using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Essence.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
