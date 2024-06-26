namespace HR_System.Models
{
    public class OfficialVacation
    {
        public int Id { get; set; }
        public string VacationName { get; set; } = default!;
        public DateTime VacationDay { get; set; }

    }
}
