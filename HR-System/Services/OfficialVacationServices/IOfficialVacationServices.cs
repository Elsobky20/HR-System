using HR_System.Models;
using HR_System.ViewModels;

namespace HR_System.Services.OfficialVacationServices
{
    public interface IOfficialVacationServices
    {
        public void Add(OfficialVacationVM model);
        public void Update(OfficialVacationVM model);
        public List<OfficialVacation> GetAll();
    }
}
