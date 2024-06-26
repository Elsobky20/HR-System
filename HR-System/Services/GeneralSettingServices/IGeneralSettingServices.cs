using HR_System.ViewModels;

namespace HR_System.Services.GeneralSettingServices
{
    public interface IGeneralSettingServices
    {
        public void AddSetting(GeneralSettingVM model);
        public void UpdateSetting(GeneralSettingVM model);
    }
}
