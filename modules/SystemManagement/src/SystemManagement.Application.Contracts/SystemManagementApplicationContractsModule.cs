using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace SystemManagement
{
    [DependsOn(
        typeof(SystemManagementDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class SystemManagementApplicationContractsModule : AbpModule
    {

    }
}
