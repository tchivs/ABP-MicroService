using Volo.Abp.Modularity;

namespace Basic.Blazor.WebAssembly
{
    [DependsOn(
        typeof(BasicBlazorModule),
        typeof(BasicHttpApiClientModule),
        typeof(Tchivs.Abp.Blazor.Theme.Bootstrap.WebAssembly.TchivsAbpBlazorThemeBootstrapWebAssembly)       )]
    public class BasicBlazorWebAssemblyModule : AbpModule
    {
        
    }
}