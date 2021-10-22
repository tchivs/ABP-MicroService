using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.PermissionManagement;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Account;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Localization.ExceptionHandling;
using Tchivs.Abp.Blazor.Routing;

namespace Admin.Blazor
{
    [DependsOn(
        typeof(Tchivs.Abp.Blazor.Theme.Bootstrap.TchivsAbpBlazorThemeBootstrapModule),
        typeof(AbpAccountApplicationContractsModule),
        typeof(AbpFeatureManagementApplicationContractsModule),
        typeof(AbpIdentityApplicationContractsModule),
        typeof(AbpPermissionManagementApplicationContractsModule),
        typeof(AbpSettingManagementApplicationContractsModule),
        typeof(AbpTenantManagementApplicationContractsModule),
        typeof(Basic.BasicApplicationContractsModule),
        typeof(AbpObjectExtendingModule), 
        typeof(AbpAutoMapperModule)
        )]
    public class AdminBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            //var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            context.Services.AddAutoMapperObjectMapper<AdminBlazorModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AdminBlazorAutoMapperProfile>(validate: true);
            });

            Configure<Volo.Abp.UI.Navigation.AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new AdminMenuContributor(configuration));
            });

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(AdminBlazorModule).Assembly);
            });
           
        }
    }
}