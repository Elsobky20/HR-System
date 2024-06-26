using HR_System.DataBase;
using HR_System.Models;
using HR_System.Services.GeneralSettingServices;
using HR_System.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestCoreApp.Models;

namespace HR_System.Controllers
{
    [Authorize(Roles = clsRoles.roleAdmin + "," + clsRoles.roleUser)]
    public class GeneralSettingController : Controller
    {
        private readonly IGeneralSettingServices settingServices;

        public GeneralSettingController( IGeneralSettingServices settingServices)
        {
            this.settingServices = settingServices;
        }

        [HttpGet]
        public IActionResult Create()
        {

            GeneralSettingVM model = new GeneralSettingVM();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(GeneralSettingVM model)
        {
            if (ModelState.IsValid)
            {
                settingServices.AddSetting(model);
                return View();
            }
            return View();
        }
    }
}
