using BasicManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace BasicManagement
{
    public abstract class BasicManagementController : AbpController
    {
        protected BasicManagementController()
        {
            LocalizationResource = typeof(BasicManagementResource);
        }
    }
}
