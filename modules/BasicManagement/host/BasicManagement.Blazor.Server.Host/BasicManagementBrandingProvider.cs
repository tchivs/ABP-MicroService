using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace BasicManagement.Blazor.Server.Host
{
    [Dependency(ReplaceServices = true)]
    public class BasicManagementBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "BasicManagement";
    }
}
