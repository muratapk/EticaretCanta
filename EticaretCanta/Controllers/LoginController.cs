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
        private readonly RoleManager<AppRole> _roleManager;
        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        // form için oluştuğuum yapı

        [HttpPost]
        public async Task<IActionResult> Index(AppUserLoginDto gelen)
        {
            string[] roller = { "Admin", "User", "Editor" };

            foreach(var rolname in roller)
            {
                var roleExist = await _roleManager.RoleExistsAsync(rolname);
                if(!roleExist)
                {
                    await _roleManager.CreateAsync(new AppRole { Name = rolname } );

                }
            }


            var result=await _signInManager.PasswordSignInAsync(gelen.UserName, gelen.PassWord, false, true);
            if(result.Succeeded )
            {
                var user=await _userManager.FindByNameAsync(gelen.UserName);
                if(user!=null)
                {
                    return RedirectToAction("Index", "Main");
                }
                
            }
            return View();
        }
    }
}
