using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace SystemManagement
{
    [DependsOn(
        typeof(SystemManagementHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class SystemManagementConsoleApiClientModule : AbpModule
    {
        
    }
}
