using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace BasicManagement
{
    [DependsOn(
        typeof(BasicManagementDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class BasicManagementApplicationContractsModule : AbpModule
    {

    }
}
