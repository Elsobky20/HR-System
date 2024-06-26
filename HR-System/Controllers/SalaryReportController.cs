using HR_System.Services.EmployeeServices;
using HR_System.Services.SalaryReport;
using HR_System.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HR_System.Controllers
{
    public class SalaryReportController : Controller
    {
        private readonly ISalaryReport salaryReport;
        private readonly IEmployeeServices employee;

        public SalaryReportController(ISalaryReport salaryReport , IEmployeeServices employee )
        {
            this.salaryReport = salaryReport;
            this.employee = employee;
        }
        public IActionResult Index()
        {
            SalaryReportVM Model = new()
            {
                Employees = employee.GetAll()
            };

            return View(Model);
        }
        public IActionResult GetSalaryReport(SalaryReportVM model)
        {
           var data = salaryReport.GetSalary(model);
            return Json(data);
        }
    }
}
