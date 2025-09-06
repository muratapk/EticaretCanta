using EticaretCanta.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EticaretCanta.Component
{
    public class BestProductList:ViewComponent
    {
        private readonly Baglanti _context;

        public BestProductList(Baglanti context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var liste = _context.Products.Include(c=>c.Category).Include(t=>t.Sub_Category).Include(s=>s.Pictures).OrderByDescending(p => p.Product_Id).Take(8).ToList();
            return View(liste);
        }
    }
}
