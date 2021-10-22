using Volo.Abp.AspNetCore.Components;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Admin.Blazor.Server.Host
{
    [Dependency(ReplaceServices = true)]
    public class AdminBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "后台管理系统|Server";
        public override string LogoUrl { get=>""; }
    }
    public abstract class AdminComponentBase : AbpComponentBase
    {
        protected AdminComponentBase()
        {
            LocalizationResource = typeof(Volo.Abp.UI.Navigation.Localization.Resource.AbpUiNavigationResource);
        }
    }
}
