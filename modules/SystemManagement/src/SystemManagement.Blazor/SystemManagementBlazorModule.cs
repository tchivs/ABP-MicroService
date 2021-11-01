using Microsoft.Extensions.DependencyInjection;
using SystemManagement.Blazor.Menus;
using Tchivs.Abp.Blazor.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace SystemManagement.Blazor
{
    [DependsOn(
        typeof(SystemManagementApplicationContractsModule),
        typeof(Tchivs.Abp.Blazor.Theme.Bootstrap.TchivsAbpBlazorThemeBootstrapModule),
        typeof(AbpAutoMapperModule)
        )]
    public class SystemManagementBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<SystemManagementBlazorModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<SystemManagementBlazorAutoMapperProfile>(validate: true);
            });

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new SystemManagementMenuContributor());
            });

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(SystemManagementBlazorModule).Assembly);
            });
        }
    }
}