using EticaretCanta.Data;
using EticaretCanta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EticaretCanta.Component
{
    public class TrendProductList:ViewComponent
    {
        private readonly Baglanti _context;

        public TrendProductList(Baglanti context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            //var trendProducts = _context.Products.OrderByDescending(p=>p.Product_Id).Take(10).ToList();

            var product_List = _context.Products.Include(p => p.Category).Include(p => p.Sub_Category).Include(p => p.Pictures).ToList();


          
            return View(product_List);
        }

    }
}
