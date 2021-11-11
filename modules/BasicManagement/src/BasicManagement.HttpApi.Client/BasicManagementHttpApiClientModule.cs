using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace BasicManagement
{
    [DependsOn(
        typeof(BasicManagementApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class BasicManagementHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "BasicManagement";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(BasicManagementApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
