using Volo.Abp.Bundling;

namespace Tchivs.Abp.Blazor.Theme.Bootstrap.WebAssembly
{
    public class BlazorGlobalContributor : IBundleContributor
    {
        public void AddScripts(BundleContext context)
        {
            context.Add("_content/Microsoft.AspNetCore.Components.WebAssembly.Authentication/AuthenticationService.js");
            context.Add("_content/Volo.Abp.AspNetCore.Components.Web/libs/abp/js/abp.js");
            context.Add("_content/BootstrapBlazor/js/bootstrap.blazor.bundle.min.js");
        }

        public void AddStyles(BundleContext context)
        {
            var name = this.GetType().Namespace;
            context.BundleDefinitions.Insert(0, new BundleDefinition
            {
                Source = $"_content/{name}/libs/fontawesome/css/all.css"
            });
            context.BundleDefinitions.Insert(1, new BundleDefinition
            {
                Source = $"_content/{name}/libs/fontawesome/css/v4-shims.css"
            });
            context.Add($"_content/{name}/libs/flag-icon/css/flag-icon.css");
            context.Add("_content/BootstrapBlazor/css/bootstrap.blazor.bundle.min.css");
            context.Add("/_content/Tchivs.Abp.Blazor.Theme.Bootstrap/css/site.css");

        }
    }
}