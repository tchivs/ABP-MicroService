using Volo.Abp.Bundling;

namespace BasicManagement.Blazor.Host
{
    public class BasicManagementBlazorHostBundleContributor : IBundleContributor
    {
        public void AddScripts(BundleContext context)
        {

        }

        public void AddStyles(BundleContext context)
        {
            context.Add("main.css", true);
        }
    }
}
