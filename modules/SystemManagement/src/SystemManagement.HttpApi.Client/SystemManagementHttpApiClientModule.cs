using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace SystemManagement
{
    [DependsOn(
        typeof(SystemManagementApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class SystemManagementHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "SystemManagement";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(SystemManagementApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
