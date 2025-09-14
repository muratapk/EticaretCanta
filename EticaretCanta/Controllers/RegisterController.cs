using EticaretCanta.Dto;
using EticaretCanta.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EticaretCanta.Controllers
{
    public class RegisterController : Controller
    {
        private readonly SignInManager<AppUser> _singInManager;
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(SignInManager<AppUser> singInManager, UserManager<AppUser> userManager)
        {
            _singInManager = singInManager;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult>RegisterSave(AppUserRegisterDto gelen)
        {
            Random random = new Random();
            int code = 0;
            code = random.Next(100000, 1000000);
            AppUser appUser = new AppUser()
            {
                FirstName = gelen.FirstName,
                LastName = gelen.LastName,
                City = gelen.City,
                Email = gelen.Email,
                PhoneNumber = gelen.PhoneNumber,
                UserName = gelen.UserName,
                ConfirmCode = code
            };
            var result=await _userManager.CreateAsync(appUser, gelen.Password);
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Main");
            }
            return View();
        }

    }
}
