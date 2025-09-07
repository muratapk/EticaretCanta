using EticaretCanta.Data;
using EticaretCanta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

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
        public async Task<IActionResult>Category_details(int id)
        {
            int pageSize = 9;
          


            if (id == 0 || _context.Categories == null)
            {
                var product_List = await _context.Products.Include(p => p.Category).Include(p => p.Sub_Category).Include(p => p.Pictures).ToListAsync();
                return View(product_List);
            }
            else
            {
                var product_List =await  _context.Products.Include(p => p.Category).Include(p => p.Sub_Category).Include(p => p.Pictures).Where(p => p.Category_Id == id).ToListAsync();
                return View(product_List);
            }
            return View();
            
        }
        public async Task<IActionResult>Category_Jdetails(int id)
        {
            List<Products>product_List=new List<Products>();
            //burada ürün listesi olarak tanýmlama yap product_List
            if (id == 0 || _context.Categories == null)
            {
                 product_List = await _context.Products.Include(p => p.Category).Include(p => p.Sub_Category).Include(p => p.Pictures).ToListAsync();
                
            }
            else
            {
                 product_List = await _context.Products.Include(p => p.Category).Include(p => p.Sub_Category).Include(p => p.Pictures).Where(p => p.Category_Id == id).ToListAsync();
                
            }

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("~/Views/Shared/Partials/_CategoryProductList.cshtml",product_List);
            }

            return View(product_List);
        }
        public async Task<IActionResult> Category_keydetails(string q)
        {
            List<Products> product_List = new List<Products>();
            //burada ürün listesi olarak tanýmlama yap product_List
            if (String.IsNullOrEmpty(q))
            {
                product_List = await _context.Products.Include(p => p.Category).Include(p => p.Sub_Category).Include(p => p.Pictures).ToListAsync();

            }
            else
            {
                product_List = await _context.Products.Include(p => p.Category).Include(p => p.Sub_Category)
    .Include(p => p.Pictures).Where(p =>p.Name.Contains(q) ||p.Code.Contains(q) || p.Category.Category_Name.Contains(q)
    ).ToListAsync();

            }

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("~/Views/Shared/Partials/_CategoryProductList.cshtml", product_List);
            }

            return View(product_List);
        }
        public async Task<IActionResult> Category_sortdetails(int q)
        {
            List<Products> product_List = new List<Products>();
            //burada ürün listesi olarak tanýmlama yap product_List
            if (q==0 && q==null)
            {
                product_List = await _context.Products.Include(p => p.Category).Include(p => p.Sub_Category).Include(p => p.Pictures).ToListAsync();

            }
            else
            {
                if(q== 1)
                {
                    product_List = await _context.Products.Include(p => p.Category).Include(p => p.Sub_Category)
    .Include(p => p.Pictures).OrderBy(p => p.Price).ToListAsync();
                }
                if(q == 2  )
                {
                    product_List = await _context.Products.Include(p => p.Category).Include(p => p.Sub_Category)
    .Include(p => p.Pictures).OrderByDescending(p => p.Price).ToListAsync();
                }
                
                

            }

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("~/Views/Shared/Partials/_CategoryProductList.cshtml", product_List);
            }

            return View(product_List);
        }
    }
}
