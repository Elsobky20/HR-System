using HR_System.DataBase;
using HR_System.ViewModels;
using System.Globalization;

namespace HR_System.Services.SalaryReport
{
    public class SalaryReport: ISalaryReport
    {
        private readonly ApplicationDbContext _context;

        public SalaryReport(ApplicationDbContext Context)
        {
            _context = Context;
        }
        protected int GetAbsentDays(SalaryReportVM salaryReport)
        {
            List<DateTime> absentDays = _context.Absent.Where(x => x.EmployeeId == salaryReport.EmployeeId).Select(x => x.day).ToList();

            List<DateTime> datesInRange = absentDays.Where(x=>x>= salaryReport.DateRangeEnd &&x<= salaryReport.DateRangeEnd).ToList();
            int numberOfDays = datesInRange.Count();
            return numberOfDays;

        }
        protected int GetLateHoure(SalaryReportVM salaryReport)
        {

            int count = 0;
            var timeOfAttendForEmp = _context.Employee.Where(x => x.id == salaryReport.EmployeeId ).Select(x => x.TimeOfAttend);

            var AllLateHoure = _context.Attendance.Where(x => x.EmployeeId == salaryReport.EmployeeId && x.Date<salaryReport.DateRangeEnd &&x.Date>salaryReport.DateRangeStart).Select(x=>x.TimeOfAttend).ToList();

            //foreach ( var date in AllLateHoure)
            //{
            //    if (date == timeOfAttendForEmp))
            //    {
            //        count++;    
            //    }
            //}


            return count;

        }
        public double GetSalary(SalaryReportVM salaryReport)
        {


            double SalaryOfDay = (_context.Employee.Where(x => x.id == salaryReport.EmployeeId).Select(x => x.Salary).FirstOrDefault()) / 30;
            double SalareOfAbsentDay = GetAbsentDays(salaryReport) * SalaryOfDay;

            double salaryOfLateHour = GetLateHoure(salaryReport) * 10;// one late hour = 10 pound 

            return (_context.Employee.Where(x => x.id == salaryReport.EmployeeId).Select(x => x.Salary).FirstOrDefault()) - (SalareOfAbsentDay+ salaryOfLateHour); 
        }
    }
}
