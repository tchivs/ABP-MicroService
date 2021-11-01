using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace SystemManagement.Blazor.Server.Host
{
    [Dependency(ReplaceServices = true)]
    public class SystemManagementBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "SystemManagement";
    }
}
