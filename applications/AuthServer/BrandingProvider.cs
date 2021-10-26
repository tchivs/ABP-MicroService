using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AuthServer
{
    public class BrandingProvider : DefaultBrandingProvider, ISingletonDependency
    {
        public override string AppName => "统一身份认证服务";
    }
}
