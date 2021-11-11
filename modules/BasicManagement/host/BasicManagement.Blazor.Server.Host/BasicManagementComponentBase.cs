using BasicManagement.Localization;
using Volo.Abp.AspNetCore.Components;

namespace BasicManagement.Blazor.Server.Host
{
    public abstract class BasicManagementComponentBase : AbpComponentBase
    {
        protected BasicManagementComponentBase()
        {
            LocalizationResource = typeof(BasicManagementResource);
        }
    }
}
