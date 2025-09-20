using EticaretCanta.Models;
using EticaretCanta.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EticaretCanta.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public AdminController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }
        [HttpGet]
        public async Task<IActionResult>EditRole(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if(user==null)
            {
                return NotFound();
            }
            var userRoles = await _userManager.GetRolesAsync(user);
            var allRoles=_roleManager.Roles.Select(r=> r.Name).ToList();

            var model = new EditUserRoleViewModel {
                UserId = user.Id,
                Email = user.Email,
                SelectRole = userRoles.FirstOrDefault(),
                AllRoles = allRoles
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult>EditRole(EditUserRoleViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId.ToString());
            if(user==null)
            {
                return NotFound();
            }
            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles);
            if(!string.IsNullOrEmpty(model.SelectRole))
            {
                await _userManager.AddToRoleAsync(user, model.SelectRole);
            }
            return RedirectToAction("Index", "Admin");
        }
    }
}
