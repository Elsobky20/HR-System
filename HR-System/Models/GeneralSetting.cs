namespace HR_System.Models
{
    public class GeneralSetting
    {
        public int Id { get; set; }
        public float OverTime {  get; set; }
        public float Late {  get; set; }
        public string FirstWeekEnd { get; set; } = default!;
        public string SecondWeekEnd { get; set; } = default!;

    }
}
