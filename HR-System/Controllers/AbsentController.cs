using HR_System.Models;
using HR_System.Services.AttendanceServices;
using HR_System.ViewModels;
using Microsoft.AspNetCore.Mvc;
using HR_System.Services.EmployeeServices;
using Microsoft.AspNetCore.Authorization;
using TestCoreApp.Models;

namespace HR_System.Controllers
{
    [Authorize(Roles = clsRoles.roleAdmin)]
    public class AbsentController : Controller
    {
        private readonly IEmployeeServices _employeeServices;
        public AbsentController(IEmployeeServices employee)
        {
            _employeeServices = employee;
        }
        [HttpGet]
        public IActionResult AddAbsent()
        {
            AbsentVM viewModel = new()
            {
                Employees = _employeeServices.GetAll()
            };

            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddAbsent(AttendanceVM model)
        {


            AbsentVM viewModel = new()
            {
                Employees = _employeeServices.GetAll()
            };
            return View(viewModel);
        }
    }
}
