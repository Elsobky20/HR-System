using HR_System.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HR_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }
        // GET: AccountController
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            // Check
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new IdentityUser();
                    user = await userManager.FindByEmailAsync(model.Email);


                    if (user != null)
                    {
                        var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                        if (result.Succeeded)
                        {
                            //get User Role By Email
                            //var UserEmail = await userManager.FindByEmailAsync(model.Email);
                            var UserRole = await userManager.GetRolesAsync(user);
                            if (UserRole[0] == "Admin")
                            {
                                return RedirectToAction("Index", "Roles");
                            }
                            
                            else
                            {
                                return View(model);

                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Email Or Password InCorrect");
                            return RedirectToAction("Privacy", "Home"); 
                        }
                    }
                }
                ModelState.AddModelError("", "Email Or Password InCorrect");
                return View(model);
            }
            catch (Exception ex)
            {
                return View(model);
            }
            
        }
        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        public IActionResult Test()
        {
            
            return View();
        }
    }
}
