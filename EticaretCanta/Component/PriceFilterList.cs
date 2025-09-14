using EticaretCanta.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EticaretCanta.Component
{
    public class PriceFilterList:ViewComponent
    {
        private readonly Baglanti _context;
        public PriceFilterList(Baglanti context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var hasProduct =await _context.Products.AnyAsync();
            if(!hasProduct)
            {
                return View(new List<(string id, string label)>());
            }

            decimal minPrice =await _context.Products.MinAsync(p => p.Price);
            decimal maxPrice =await _context.Products.MaxAsync(p => p.Price);

            decimal rangeSize = 100;
            var priceRanges = new List<(string id, string label)>();
            int index = 1;

            for (decimal start = Math.Floor(minPrice / rangeSize) *rangeSize; start < maxPrice;start+=rangeSize)
            {
                decimal end = start + rangeSize;
                string label = $"${start} -${end }" ;
                string id = $"Fiyat-{index++}";
                priceRanges.Add((id, label));
            }
            return View(priceRanges);
        }
    }
}
