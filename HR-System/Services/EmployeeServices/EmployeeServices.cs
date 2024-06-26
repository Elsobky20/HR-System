using HR_System.DataBase;
using HR_System.Models;
using HR_System.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HR_System.Services.EmployeeServices
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public EmployeeServices(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext Context)
        {
            context = Context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public int Create(EmployeeVM emp)
        {
            if (emp != null)
            {
                Employee obj = new Employee();
                obj.Name = emp.Name;
                obj.DateOfBarth = emp.DateOfBarth;
                obj.Gender = emp.Gender;
                obj.Phone = emp.Phone;
                obj.Address = emp.Address;
                obj.Salary = emp.Salary;
                obj.Nationalid = emp.Nationalid;
                obj.DateOfWork = DateTime.Now;
                obj.TimeOfAttend = emp.TimeOfAttend;
                obj.TimeOfLeave = emp.TimeOfLeave;
                obj.Nationality = emp.Nationality;
                context.Add(obj);
                context.SaveChanges();
                return 1;
            }
            return 0;
        }

        public IEnumerable<Employee> GetAll()
        {
            return context.Employee.ToList();
        }

        public EmployeeVM GetByID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
