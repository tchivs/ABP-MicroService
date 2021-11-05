using Volo.Abp.Modularity;

namespace Basic
{
    [DependsOn(
        typeof(BasicApplicationModule),
        typeof(BasicDomainTestModule)
        )]
    public class BasicApplicationTestModule : AbpModule
    {

    }
}
