using HR_System.DataBase;
using HR_System.Models;
using HR_System.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace HR_System.Services.GeneralSettingServices
{
    public class GeneralSettingServices : IGeneralSettingServices
    {
        private readonly ApplicationDbContext _context;

        public GeneralSettingServices(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddSetting(GeneralSettingVM model)
        {
            GeneralSetting obj = new GeneralSetting();
            obj.OverTime = model.OverTime;
            obj.Late = model.Late;
            obj.FirstWeekEnd = model.FirstWeekEnd;
            obj.SecondWeekEnd = model.SecondWeekEnd;
            _context.Add(obj);
            _context.SaveChanges();
        }

        public void UpdateSetting(GeneralSettingVM model)
        {
            GeneralSetting oldData = _context.GeneralSetting.FirstOrDefault();
            if (oldData != null)
            {
                oldData.FirstWeekEnd = model.FirstWeekEnd;
                oldData.SecondWeekEnd= model.SecondWeekEnd;
                oldData.Late = model.Late;
                oldData.OverTime = model.OverTime;
                _context.SaveChanges();
            }


        }
    }
}
