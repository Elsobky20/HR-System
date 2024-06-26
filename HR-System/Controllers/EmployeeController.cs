using HR_System.Services.EmployeeServices;
using HR_System.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestCoreApp.Models;

namespace HR_System.Controllers
{
    [Authorize(Roles = clsRoles.roleAdmin + "," +clsRoles.roleUser)]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServices _employeeServices;
        public EmployeeController(IEmployeeServices employee)
        { 
            this._employeeServices = employee;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeVM model) 
        {
            if (ModelState.IsValid)
            {
                _employeeServices.Create(model);
            }
            else
            {
                ModelState.AddModelError("", "S");
            }
            return RedirectToAction("Login","Account");
        }
    }
}
