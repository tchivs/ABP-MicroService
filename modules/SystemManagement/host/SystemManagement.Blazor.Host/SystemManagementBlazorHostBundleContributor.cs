using Volo.Abp.Bundling;

namespace SystemManagement.Blazor.Host
{
    public class SystemManagementBlazorHostBundleContributor : IBundleContributor
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
