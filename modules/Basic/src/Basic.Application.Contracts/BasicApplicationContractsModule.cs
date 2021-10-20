using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Basic
{
    [DependsOn(
        typeof(BasicDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class BasicApplicationContractsModule : AbpModule
    {

    }
}
