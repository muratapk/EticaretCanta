using EticaretCanta.Data;
using EticaretCanta.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace EticaretCanta.Controllers
{
    public class CartController : Controller
    {
        private const string CartKey = "cart";
        private readonly Baglanti _context;

        public CartController(Baglanti context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = GetCart();
                     
            return View(cart);
        }
        private Carts GetCart()
        {
            var cart = HttpContext.Session.GetObject<Carts>("cart");
            if (cart == null)
            {
                cart = new Carts();
                HttpContext.Session.SetObject("cart", cart);
            }
            return cart;
        }
        [HttpPost]
        public IActionResult Add(int Product_Id, int quantity)
        {
            var product = _context.Products.FirstOrDefault(p => p.Product_Id == Product_Id);
            if (product != null)
            {
                var cart = GetCart();
                cart.AddToCart(product, quantity);
                HttpContext.Session.SetObject(CartKey, cart);

            }
            return RedirectToAction("Index", "Cart");
        }
    }
}
