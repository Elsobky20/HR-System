namespace HR_System.ViewModels
{
    public class EmployeeVM
    {

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public DateTime DateOfBarth { get; set; }
        public string Nationalid { get; set; } = string.Empty;
        public double Salary { get; set; }
        public DateTime DateOfWork { get; set; }
        public DateTime TimeOfAttend { get; set; }
        public DateTime TimeOfLeave { get; set; }
    }
}
