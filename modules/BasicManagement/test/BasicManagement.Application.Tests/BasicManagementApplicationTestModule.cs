using Volo.Abp.Modularity;

namespace BasicManagement
{
    [DependsOn(
        typeof(BasicManagementApplicationModule),
        typeof(BasicManagementDomainTestModule)
        )]
    public class BasicManagementApplicationTestModule : AbpModule
    {

    }
}
