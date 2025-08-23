using Microsoft.AspNetCore.Mvc;

namespace EticaretCanta.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
