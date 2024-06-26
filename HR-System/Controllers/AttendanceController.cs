using HR_System.Models;
using HR_System.Services;
using HR_System.Services.AttendanceServices;
using HR_System.Services.EmployeeServices;
using HR_System.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestCoreApp.Models;

namespace HR_System.Controllers
{
    [Authorize(Roles = clsRoles.roleAdmin + "," + clsRoles.roleUser)]
    public class AttendanceController : Controller
    {
        private readonly IEmployeeServices _employeeServices;
        private readonly IAttendanceServices _attendance;

        public AttendanceController(IEmployeeServices employee,IAttendanceServices attendance) 
        {  
            _employeeServices = employee;
            _attendance = attendance;
        }   
        [HttpGet]
        public IActionResult AddAttend()
        {
            AttendanceVM viewModel = new()
            {
                Employees = _employeeServices.GetAll()
            };
               
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult AddAttend(AttendanceVM model)
        {
            if (ModelState.IsValid)
            {
                _attendance.Add(model);
            }

            AttendanceVM viewModel = new()
            {
                Employees = _employeeServices.GetAll()
            };
            return View(viewModel);
        }


    }
}
