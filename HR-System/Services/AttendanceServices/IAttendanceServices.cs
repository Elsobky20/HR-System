using HR_System.Models;
using HR_System.ViewModels;

namespace HR_System.Services.AttendanceServices
{
    public interface IAttendanceServices
    {
        void Add(AttendanceVM attendance);
        IEnumerable<AttendanceVM> GetAll();
    }
}
