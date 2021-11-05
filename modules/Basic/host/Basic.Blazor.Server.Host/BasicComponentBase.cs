using Basic.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Basic.Blazor.Server.Host
{
    public abstract class BasicComponentBase : AbpComponentBase
    {
        protected BasicComponentBase()
        {
            LocalizationResource = typeof(BasicResource);
        }
    }
}
