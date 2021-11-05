using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Basic.Blazor.Server.Host
{
    [Dependency(ReplaceServices = true)]
    public class BasicBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Basic";
    }
}
