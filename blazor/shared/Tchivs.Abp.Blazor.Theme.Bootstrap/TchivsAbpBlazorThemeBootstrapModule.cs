using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tchivs.Abp.Blazor.Routing;
using Volo.Abp.Modularity;

namespace Tchivs.Abp.Blazor.Theme.Bootstrap
{
    [DependsOn(typeof(Tchivs.Abp.Blazor.TchivsAbpBlazorModule))]
    public class TchivsAbpBlazorThemeBootstrapModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(TchivsAbpBlazorThemeBootstrapModule).Assembly);
            });
            context.Services.AddAuthorizationCore();
            context.Services.AddBootstrapBlazor();
        }
    }
}