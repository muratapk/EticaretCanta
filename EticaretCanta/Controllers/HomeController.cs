using EticaretCanta.Data;
using EticaretCanta.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EticaretCanta.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Baglanti _context;
        public HomeController(ILogger<HomeController> logger,Baglanti context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> Product_Details(int ? id)
        {
            var product_List=_context.Products.FirstOrDefault(p => p.Product_Id == id);
            return View(product_List);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
