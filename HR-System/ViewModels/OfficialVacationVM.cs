namespace HR_System.ViewModels
{
    public class OfficialVacationVM
    {
        public int Id { get; set; }
        public string VacationName { get; set; } = default!;
        public DateTime VacationDay { get; set; }
    }
}
