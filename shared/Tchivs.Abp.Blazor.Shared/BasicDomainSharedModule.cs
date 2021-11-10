
using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using Tchivs.Abp.Blazor.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Tchivs.Abp.Blazor
{
    [DependsOn(
        typeof(AbpValidationModule)
    )]
    public class TchivsAbpBlazorSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            
        }
    }
}