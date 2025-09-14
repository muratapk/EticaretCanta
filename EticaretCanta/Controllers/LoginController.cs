using EticaretCanta.Dto;
using EticaretCanta.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace EticaretCanta.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        // form için oluştuğuum yapı

        [HttpPost]
        public async Task<IActionResult> Index(AppUserLoginDto gelen)
        {
            var result=await _signInManager.PasswordSignInAsync(gelen.UserName, gelen.PassWord, false, true);
            if(result.Succeeded )
            {
                var user=_userManager.FindByNameAsync(gelen.UserName);
                if(user!=null)
                {
                    return RedirectToAction("Index", "Main");
                }
                
            }
            return View();
        }
    }
}
