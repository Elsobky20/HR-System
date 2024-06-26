using HR_System.Models;

namespace HR_System.ViewModels
{
    public class AttendanceVM
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeOfAttend { get; set; }
        public DateTime TimeOfLeave { get; set; }
        public bool ISAttend { get; set; }
        public int EmployeeId { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
    }
}
