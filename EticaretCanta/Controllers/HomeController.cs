using EticaretCanta.Data;
using EticaretCanta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            //var product_List=_context.Products.FirstOrDefault(p => p.Product_Id == id);
            var product_List=await _context.Products.Include(p=>p.Category).Include(p=>p.Sub_Category).Include(p => p.Pictures).FirstOrDefaultAsync(p => p.Product_Id == id);

            if (product_List == null)
            {
                return NotFound();
            }
            var viewModel = new ProductWithPictures
            {
                Product = product_List,
                Pictures = product_List.Pictures.ToList()
            };
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
