using HR_System.Models;

namespace HR_System.ViewModels
{
    public class SalaryReportVM
    {
        public DateTime DateRangeStart {  get; set; }
        public DateTime DateRangeEnd { get; set;}
        public int EmployeeId { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
