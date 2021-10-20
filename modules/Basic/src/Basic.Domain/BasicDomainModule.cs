using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Basic
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(BasicDomainSharedModule)
    )]
    public class BasicDomainModule : AbpModule
    {

    }
}
