using SystemManagement.Localization;
using Volo.Abp.AspNetCore.Components;

namespace SystemManagement.Blazor.Server.Host
{
    public abstract class SystemManagementComponentBase : AbpComponentBase
    {
        protected SystemManagementComponentBase()
        {
            LocalizationResource = typeof(SystemManagementResource);
        }
    }
}
