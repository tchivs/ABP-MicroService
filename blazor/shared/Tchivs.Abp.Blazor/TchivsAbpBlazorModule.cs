using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Basic;
using Tchivs.Abp.Blazor.Routing;
using Volo.Abp.Application;
using Volo.Abp.AspNetCore.Components.Messages;
using Volo.Abp.AspNetCore.Components.Web;
using Volo.Abp.Authorization;
using Volo.Abp.ExceptionHandling;
using Volo.Abp.ExceptionHandling.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation;
using Volo.Abp.VirtualFileSystem;

namespace Tchivs.Abp.Blazor
{
    [DependsOn(
        typeof(AbpExceptionHandlingModule),typeof(TchivsAbpBlazorSharedModule),
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
