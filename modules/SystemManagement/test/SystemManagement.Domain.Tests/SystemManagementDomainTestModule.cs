using SystemManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SystemManagement
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(SystemManagementEntityFrameworkCoreTestModule)
        )]
    public class SystemManagementDomainTestModule : AbpModule
    {
        
    }
}
