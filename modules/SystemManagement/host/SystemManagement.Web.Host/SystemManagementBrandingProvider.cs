using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace SystemManagement
{
    [Dependency(ReplaceServices = true)]
    public class SystemManagementBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "SystemManagement";
    }
}
