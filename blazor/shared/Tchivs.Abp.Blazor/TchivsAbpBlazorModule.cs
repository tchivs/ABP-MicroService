using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Tchivs.Abp.Blazor.Routing;
using Volo.Abp.Application;
using Volo.Abp.AspNetCore.Components.Messages;
using Volo.Abp.AspNetCore.Components.Web;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
namespace Tchivs.Abp.Blazor
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsWebModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule), 
        typeof(AbpUiNavigationModule)
        )]
    public class TchivsAbpBlazorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddSingleton(typeof(AbpBlazorMessageLocalizerHelper<>));
            ConfigureRouter(context);
        }
        private void ConfigureRouter(ServiceConfigurationContext context)
        {
            Configure<AbpRouterOptions>(options =>
            {
                options.AppAssembly = typeof(TchivsAbpBlazorModule).Assembly;
            });
        }
    }
}
