
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
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<TchivsAbpBlazorSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<BlazorUIResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/BlazorUI");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("BlazorUI", typeof(BlazorUIResource));
            });
        }
    }
}