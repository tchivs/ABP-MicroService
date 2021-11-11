using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace BasicManagement
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(BasicManagementDomainSharedModule)
    )]
    public class BasicManagementDomainModule : AbpModule
    {

    }
}
