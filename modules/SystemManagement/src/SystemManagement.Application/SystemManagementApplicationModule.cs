using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace SystemManagement
{
    [DependsOn(
        typeof(SystemManagementDomainModule),
        typeof(SystemManagementApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    public class SystemManagementApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<SystemManagementApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<SystemManagementApplicationModule>(validate: true);
            });
        }
    }
}
