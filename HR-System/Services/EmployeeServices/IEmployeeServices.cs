using HR_System.Models;
using HR_System.ViewModels;

namespace HR_System.Services.EmployeeServices
{
    public interface IEmployeeServices
    {
        int Create(EmployeeVM emp);
        IEnumerable<Employee> GetAll();
        EmployeeVM GetByID(int id);
    }
}
