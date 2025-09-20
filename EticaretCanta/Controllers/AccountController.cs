using Microsoft.AspNetCore.Mvc;

namespace EticaretCanta.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return RedirectToAction("Index", "Login");
        }
        public IActionResult AcceessDenied()
        {
            return View("Sayfa Bulunamadı");
        }
    }
}
