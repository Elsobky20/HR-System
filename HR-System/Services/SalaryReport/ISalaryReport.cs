using HR_System.ViewModels;

namespace HR_System.Services.SalaryReport
{
    public interface ISalaryReport
    {
        public double GetSalary(SalaryReportVM salaryReport); 
    }
}
