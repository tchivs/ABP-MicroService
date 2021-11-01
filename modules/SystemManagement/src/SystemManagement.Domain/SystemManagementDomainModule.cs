using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace SystemManagement
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(SystemManagementDomainSharedModule)
    )]
    public class SystemManagementDomainModule : AbpModule
    {

    }
}
