using EticaretCanta.Models;

namespace EticaretCanta.ViewModel
{
    public class Carts
    {
        public List<CartItems> items { get; set; } = new();
        //CartItems rehber alıyor...
        public void AddToCart(Products products,int quantity)
        {
            var existing=items.FirstOrDefault(i => i.Products.Product_Id == products.Product_Id);
            if(existing != null)
            {
                existing.Quantity += quantity;
            }
            else
            {
                items.Add(new CartItems
                {
                    Products = products,
                    Quantity = quantity
                });
            }
        }
        public decimal TotalPrice()
        {
            return items.Sum(i => i.Products.Price * i.Quantity);
        }
    }
}
