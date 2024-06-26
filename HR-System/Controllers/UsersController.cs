using HR_System.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCoreApp.Models;

namespace HR_System.Controllers
{
    [Authorize(Roles = clsRoles.roleAdmin)]
    public class UsersController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roles;
        public UsersController(UserManager<IdentityUser> user, RoleManager<IdentityRole> roles)
        {
            _userManager = user;
            _roles = roles;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task< IActionResult> AddUser()
        {
            var roles = await _roles.Roles.Select(r => new roleViewModel { roleId = r.Id, roleName = r.Name }).ToListAsync();
            var viewModel = new AddUserViewModel
            {
                roles = roles
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(AddUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (!model.roles.Any(r => r.IsSelected))
            {
                ModelState.AddModelError("roles", "Please select role");
                return View(model);
            }
            if (await _userManager.FindByEmailAsync(model.Email)!=null)
            {
                ModelState.AddModelError("Email", "EmiaL Is already exists");
                return View(model);
            }
            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.UserName
            };
            var result = await _userManager.CreateAsync(user,model.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("Email", error.Description);
                    return View(model);
                }
            }
            await _userManager.AddToRolesAsync(user, model.roles.Where(r=>r.IsSelected).Select(r => r.roleName));

            return RedirectToAction("Index", "Roles");
        }
    }
}
