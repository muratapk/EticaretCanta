using EticaretCanta.Models;
using System.Diagnostics.Eventing.Reader;

namespace EticaretCanta.ViewModel
{
    public class CartItems
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Picture { get; set; }
        public CartItems()
        {

        }
        

        public Products Products { get;set; }
        public int Quantity { get; set; }
    }
}
