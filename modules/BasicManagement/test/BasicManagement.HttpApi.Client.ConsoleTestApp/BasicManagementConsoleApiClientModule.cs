using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace BasicManagement
{
    [DependsOn(
        typeof(BasicManagementHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class BasicManagementConsoleApiClientModule : AbpModule
    {
        
    }
}
