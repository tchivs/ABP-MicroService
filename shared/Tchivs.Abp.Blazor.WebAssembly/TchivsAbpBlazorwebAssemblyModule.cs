using Microsoft.AspNetCore.Components.Authorization;
using Volo.Abp.AspNetCore.Components.WebAssembly;
using Volo.Abp.Bundling;
using Volo.Abp.Http.Client.IdentityModel.WebAssembly;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Tchivs.Abp.Blazor.Routing;

namespace Tchivs.Abp.Blazor.WebAssembly
{
    [DependsOn(
        typeof(Tchivs.Abp.Blazor.TchivsAbpBlazorModule),
    typeof(AbpHttpClientIdentityModelWebAssemblyModule),
        typeof(AbpAspNetCoreComponentsWebAssemblyModule)
    )]
    public abstract class TchivsAbpBlazorwebAssemblyModule<TBundleContributor> : AbpModule
        where TBundleContributor : IBundleContributor
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpToolbarOptions>(options =>
            {
                options.Contributors.Add(GetToolbarContributor());
            });
            Configure<AbpRouterOptions>(options =>
            {
                options.AdditionalAssemblies.Add(typeof(Pages.Authentication).Assembly);
            });
        }

        protected abstract IToolbarContributor GetToolbarContributor();
    }

}
