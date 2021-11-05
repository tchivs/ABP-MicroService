using Microsoft.Extensions.DependencyInjection;
using Basic.Blazor.Menus;
using Tchivs.Abp.Blazor.Routing;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;

namespace Basic.Blazor
{
    [DependsOn(
        typeof(BasicApplicationContractsModule),
        typeof(Tchivs.Abp.Blazor.Theme.Bootstrap.TchivsAbpBlazorThemeBootstrapModule),
        typeof(AbpAutoMapperModule)
        )]
    public class BasicBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<BasicBlazorModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<BasicBlazorAutoMapperProfile>(validate: true);
            });

            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new BasicMenuContributor());
            });

            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(BasicBlazorModule).Assembly);
            });
        }
    }
}