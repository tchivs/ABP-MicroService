using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AuthServer
{
    public class BrandingProvider : DefaultBrandingProvider, ISingletonDependency
    {
        public override string AppName => "Authentication Server";
    }
}
