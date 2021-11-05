using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Basic
{
    [DependsOn(
        typeof(BasicApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class BasicHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Basic";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(BasicApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
