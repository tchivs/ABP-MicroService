using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace BasicManagement.Blazor.WebAssembly
{
    [DependsOn(
        typeof(BasicManagementBlazorModule),
        typeof(BasicManagementHttpApiClientModule),
        typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
        )]
    public class BasicManagementBlazorWebAssemblyModule : AbpModule
    {
        
    }
}