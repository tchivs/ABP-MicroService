using Volo.Abp.Modularity;

namespace SystemManagement.Blazor.WebAssembly
{
    [DependsOn(
        typeof(SystemManagementBlazorModule),
        typeof(SystemManagementHttpApiClientModule),typeof(Tchivs.Abp.Blazor.Theme.Bootstrap.WebAssembly.TchivsAbpBlazorThemeBootstrapWebAssembly)
        )]
    public class SystemManagementBlazorWebAssemblyModule : AbpModule
    {
        
    }
}