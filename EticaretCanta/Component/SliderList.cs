using EticaretCanta.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EticaretCanta.Component
{
    public class SliderList:ViewComponent
    {
        private readonly Baglanti _context;
        public SliderList(Baglanti context)
        {
            _context = context;
        }   
        public IViewComponentResult Invoke()
        {
            var product_List = _context.Products.Include(p => p.Category).Include(p => p.Sub_Category).Include(p => p.Pictures).Take(5).OrderByDescending(p=>p.Product_Id).ToList();
            return View(product_List);
        }
    }
}
