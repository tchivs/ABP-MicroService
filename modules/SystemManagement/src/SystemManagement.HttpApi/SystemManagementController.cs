using SystemManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SystemManagement
{
    public abstract class SystemManagementController : AbpController
    {
        protected SystemManagementController()
        {
            LocalizationResource = typeof(SystemManagementResource);
        }
    }
}
