using EticaretCanta.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EticaretCanta.Controllers
{
    public class RoleTestController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RoleTestController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult>AssignAdminRole()
        {
            var user = await _userManager.FindByEmailAsync("admin@admin.com");
            //kullanıcı var ise user
            if(user!=null && !(await _userManager.IsInRoleAsync(user,"Admin")))
            {
                await _userManager.AddToRoleAsync(user, "Admin");
                return Content("Admin Rolü Atandı");
            }
            return Content("Kullanıcı Yok veya Zaten Admin");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
