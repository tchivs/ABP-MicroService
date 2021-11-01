using Localization.Resources.AbpUi;
using SystemManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace SystemManagement
{
    [DependsOn(
        typeof(SystemManagementApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class SystemManagementHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(SystemManagementHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<SystemManagementResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
