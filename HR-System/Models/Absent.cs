using System.ComponentModel.DataAnnotations.Schema;

namespace HR_System.Models
{
    public class Absent
    {
        public int Id { get; set; }
        public DateTime day { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = default!;

    }
}
