using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Volo.Abp.AspNetCore.Components.Server;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Packages;
using Volo.Abp.Modularity;
using Tchivs.Abp.Blazor;
namespace Tchivs.Abp.Blazor.Server
{
    [DependsOn(
        typeof(Tchivs.Abp.Blazor.TchivsAbpBlazorModule),
    typeof(AbpAspNetCoreComponentsServerModule),
    typeof(AbpAspNetCoreMvcUiPackagesModule),
    typeof(AbpAspNetCoreMvcUiBundlingModule)
    )]
    public abstract class TchivsAbpBlazorServerModule<TStyleBundleContributor, TScriptBundleContributor> : AbpModule
        where TStyleBundleContributor : BundleContributor
       where TScriptBundleContributor : BundleContributor
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpToolbarOptions>(options =>
            {
                options.Contributors.Add(GetToolbarContributor());
            });
            Configure<AbpBundlingOptions>(options =>
            {
                options
                    .StyleBundles
                    .Add(BlazorThemeBundles.Styles.Global,
                        bundle => { bundle.AddContributors(typeof(TStyleBundleContributor)); });

                options
                    .ScriptBundles
                    .Add(BlazorThemeBundles.Scripts.Global,
                        bundle => { bundle.AddContributors(typeof(TScriptBundleContributor)); });
            });
        }

        protected abstract IToolbarContributor GetToolbarContributor();
    }
    public class BlazorThemeBundles
    {
        public static class Styles
        {
            public static string Global = "Blazor.Theme.Global";
        }

        public static class Scripts
        {
            public static string Global = "Blazor.Theme.Global";
        }
    }
}
