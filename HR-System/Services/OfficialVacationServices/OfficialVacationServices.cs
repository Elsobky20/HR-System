using HR_System.DataBase;
using HR_System.Models;
using HR_System.ViewModels;

namespace HR_System.Services.OfficialVacationServices
{
    public class OfficialVacationServices : IOfficialVacationServices
    {
        private readonly ApplicationDbContext _context;

        public OfficialVacationServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Add(OfficialVacationVM model)
        {
            OfficialVacation obj = new OfficialVacation();
            obj.VacationDay = model.VacationDay;
            obj.VacationName = model.VacationName;
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void Update(OfficialVacationVM model)
        {
            OfficialVacation oldData = _context.OfficialVacation.Where(x=>x.Id==model.Id).FirstOrDefault();
            if (oldData != null)
            {
                oldData.VacationDay = model.VacationDay;
                oldData.VacationName = model.VacationName;
                _context.SaveChanges();
            }
        }

        public List<OfficialVacation> GetAll()
        {
            var AllVacation = _context.OfficialVacation.ToList();
            return AllVacation;
        }

    }
}
