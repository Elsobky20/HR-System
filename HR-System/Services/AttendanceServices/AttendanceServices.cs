using HR_System.DataBase;
using HR_System.Models;
using HR_System.ViewModels;

namespace HR_System.Services.AttendanceServices
{
    public class AttendanceServices : IAttendanceServices
    {
        private readonly ApplicationDbContext _context;
        public AttendanceServices(ApplicationDbContext context)
        {
            this._context = context;
        }
        public void Add(AttendanceVM attendance)
        {    
            if (attendance != null)
            {
                Attendance obj = new Attendance();
                var Status = _context.Attendance.Where(x => x.Date == attendance.Date && x.EmployeeId == attendance.EmployeeId).FirstOrDefault();

                if (Status==null )
                {
                    //add
                    obj.Date = attendance.Date;
                    obj.EmployeeId = attendance.EmployeeId;
                    obj.TimeOfAttend= attendance.TimeOfAttend;
                    obj.ISAttend = true;
                    _context.Add(obj);
                    _context.SaveChanges();
                }
                else
                {
                    //update
                    var oldData=_context.Attendance.Where(x => x.Date == attendance.Date && x.EmployeeId == attendance.EmployeeId).FirstOrDefault();
                    if (oldData!=null)
                    {
                        oldData.TimeOfLeave = attendance.TimeOfLeave;
                        _context.SaveChanges();
                    }

                }


            }
        }

        public IEnumerable<AttendanceVM> GetAll()
        {
            List<AttendanceVM> attendances = new List<AttendanceVM>();
            foreach (var item in _context.Attendance)
            {
                AttendanceVM obj = new AttendanceVM();
                obj.Date = item.Date;
                obj.EmployeeId = item.EmployeeId;
                obj.ISAttend    = item.ISAttend;
                obj.TimeOfAttend = item.TimeOfAttend;
                obj.TimeOfLeave= item.TimeOfLeave;
                obj.Id = item.Id;
                attendances.Add(obj);
            }
            return attendances;
        }
    }
}
