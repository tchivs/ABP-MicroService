using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;

namespace Tchivs.Abp.Blazor.Theme.Bootstrap
{
    [DependsOn(typeof(Tchivs.Abp.Blazor.TchivsAbpBlazorModule))]
    public class TchivsAbpBlazorThemeBootstrapModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddBootstrapBlazor();
        }
    }

}
