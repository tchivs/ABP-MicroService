using Volo.Abp.Modularity;

namespace SystemManagement
{
    [DependsOn(
        typeof(SystemManagementApplicationModule),
        typeof(SystemManagementDomainTestModule)
        )]
    public class SystemManagementApplicationTestModule : AbpModule
    {

    }
}
