using EticaretCanta.Data;
using Microsoft.AspNetCore.Mvc;

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
            var trendProducts = _context.Products.OrderByDescending(p=>p.Product_Id).Take(10).ToList();
            return View(trendProducts);
        }

    }
}
