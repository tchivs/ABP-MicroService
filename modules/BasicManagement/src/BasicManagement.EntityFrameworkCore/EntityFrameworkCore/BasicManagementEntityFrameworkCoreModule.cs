using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace BasicManagement.EntityFrameworkCore
{
    [DependsOn(
        typeof(BasicManagementDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class BasicManagementEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<BasicManagementDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options
                    .AddRepository<DataDictionaries.DataDictionary,
                        Repository.DataDictionaries.DataDictionaryRepository>();
            });
        }
    }
}