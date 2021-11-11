using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tchivs.Abp.Blazor.WebAssembly;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Components.Authorization;
using Volo.Abp.AspNetCore.Components.WebAssembly;
using Volo.Abp.Bundling;
using Volo.Abp.Http.Client.IdentityModel.WebAssembly;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Tchivs.Abp.Blazor.Theme.Bootstrap.WebAssembly.Components;

namespace Tchivs.Abp.Blazor.Theme.Bootstrap.WebAssembly
{
    [DependsOn(typeof(Tchivs.Abp.Blazor.Theme.Bootstrap.TchivsAbpBlazorThemeBootstrapModule))]
    public class TchivsAbpBlazorThemeBootstrapWebAssembly : TchivsAbpBlazorwebAssemblyModule<BlazorGlobalContributor>
    {
        protected override IToolbarContributor GetToolbarContributor()
        {
            return new ToolbarContributor();
        }
    }
    public class ToolbarContributor : IToolbarContributor
    {
        public Task ConfigureToolbarAsync(IToolbarConfigurationContext context)
        {
            if (context.Toolbar.Name == StandardToolbars.Main)
            {
               context.Toolbar.Items.Add(new ToolbarItem(typeof(LanguageSwitch)));
               context.Toolbar.Items.Add(new ToolbarItem(typeof(LoginDisplay)));
            }

            return Task.CompletedTask;
        }
    }
    

   
}
