using Volo.Abp.Modularity;

namespace BasicManagement.Blazor.WebAssembly
{
    [DependsOn(
        typeof(BasicManagementBlazorModule),
        typeof(BasicManagementHttpApiClientModule),
        typeof(Tchivs.Abp.Blazor.Theme.Bootstrap.WebAssembly.TchivsAbpBlazorThemeBootstrapWebAssembly)
        )]
    public class BasicManagementBlazorWebAssemblyModule : AbpModule
    {
        
    }
}