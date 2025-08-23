using EticaretCanta.Data;
using Microsoft.AspNetCore.Mvc;

namespace EticaretCanta.Component
{
    public class CategoryList:ViewComponent
    {
        private readonly Baglanti _context;

        public CategoryList(Baglanti context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }   
    }
}
