using HR_System.DataBase;
using HR_System.Models;
using HR_System.Services.OfficialVacationServices;
using HR_System.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestCoreApp.Models;

namespace HR_System.Controllers
{
    [Authorize(Roles = clsRoles.roleAdmin + "," + clsRoles.roleUser)]
    public class OfficialVacationController : Controller
    {
        private readonly IOfficialVacationServices vacationServices;

        public OfficialVacationController(IOfficialVacationServices vacationServices)
        {
            this.vacationServices = vacationServices;
        }

        [HttpGet]
        public IActionResult Create()
        {

            OfficialVacationVM model = new OfficialVacationVM();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(OfficialVacationVM model)
        {
            if (ModelState.IsValid)
            {
                vacationServices.Add(model);
            }
            return View();
        }
    }
}
