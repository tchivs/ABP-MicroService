using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace SystemManagement
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(Volo.Abp.PermissionManagement.AbpPermissionManagementDomainModule),
        typeof(SystemManagementDomainSharedModule)
    )]
    public class SystemManagementDomainModule : AbpModule
    {

    }
}
