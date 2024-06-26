using System.ComponentModel.DataAnnotations;

namespace HR_System.Models
{
    public class Attendance
    {
        
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeOfAttend { get; set; }
        public DateTime TimeOfLeave { get; set; }
        public bool ISAttend { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = default!;

    }
}
