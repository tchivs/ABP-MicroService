using SystemManagement.Localization;
using Volo.Abp.Application.Services;

namespace SystemManagement
{
    public abstract class SystemManagementAppService : ApplicationService
    {
        protected SystemManagementAppService()
        {
            LocalizationResource = typeof(SystemManagementResource);
            ObjectMapperContext = typeof(SystemManagementApplicationModule);
        }
    }
}
