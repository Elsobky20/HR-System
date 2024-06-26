namespace HR_System.ViewModels
{
    public class GeneralSettingVM
    {
        public int Id { get; set; }
        public float OverTime { get; set; }
        public float Late { get; set; }
        public string FirstWeekEnd { get; set; } = default!;
        public string SecondWeekEnd { get; set; } = default!;
    }
}
