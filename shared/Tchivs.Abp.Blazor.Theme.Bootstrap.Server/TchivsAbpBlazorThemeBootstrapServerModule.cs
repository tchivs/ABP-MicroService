using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tchivs.Abp.Blazor.Server;
using Tchivs.Abp.Blazor.Theme.Bootstrap.Server.Components;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages.FontAwesome;
using Volo.Abp.Modularity;

namespace Tchivs.Abp.Blazor.Theme.Bootstrap.Server
{
    [DependsOn(typeof(Tchivs.Abp.Blazor.Theme.Bootstrap.TchivsAbpBlazorThemeBootstrapModule))]
    public class TchivsAbpBlazorThemeBootstrapServerModule : TchivsAbpBlazorServerModule<BlazorGlobalStyleContributor, BlazorGlobalScriptContributor>
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
    public class BlazorGlobalScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains("/_framework/blazor.server.js");
            context.Files.AddIfNotContains("/_content/BootstrapBlazor/js/bootstrap.blazor.bundle.min.js");
            context.Files.AddIfNotContains("/_content/Volo.Abp.AspNetCore.Components.Web/libs/abp/js/abp.js");
        }
    }

    [DependsOn(

        typeof(FontAwesomeStyleContributor)
    )]
    public class BlazorGlobalStyleContributor : BundleContributor
    {

        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains("/_content/BootstrapBlazor/css/bootstrap.blazor.bundle.min.css");
            context.Files.AddIfNotContains("/_content/Tchivs.Abp.Blazor.Theme.Bootstrap/css/site.css");
        }
    }
}
