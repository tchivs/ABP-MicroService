using Volo.Abp.Modularity;

namespace Basic.Blazor.Server
{
    [DependsOn(
        typeof(Tchivs.Abp.Blazor.Theme.Bootstrap.Server.TchivsAbpBlazorThemeBootstrapServerModule),
        typeof(BasicBlazorModule)
        )]
    public class BasicBlazorServerModule : AbpModule
    {
        
    }
}