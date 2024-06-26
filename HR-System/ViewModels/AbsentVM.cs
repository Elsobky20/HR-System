using HR_System.Models;

namespace HR_System.ViewModels
{
    public class AbsentVM
    {
        public int Id { get; set; }
        public DateTime day { get; set; }
        public int EmployeeId { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
