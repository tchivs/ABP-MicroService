using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace SystemManagement.EntityFrameworkCore
{
    [DependsOn(
        typeof(SystemManagementDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class SystemManagementEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<SystemManagementDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
            });
        }
    }
}