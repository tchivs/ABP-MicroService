using BasicManagement.Localization;
using Volo.Abp.Application.Services;

namespace BasicManagement
{
    public abstract class BasicManagementAppService : ApplicationService
    {
        protected BasicManagementAppService()
        {
            LocalizationResource = typeof(BasicManagementResource);
            ObjectMapperContext = typeof(BasicManagementApplicationModule);
        }
    }
}
