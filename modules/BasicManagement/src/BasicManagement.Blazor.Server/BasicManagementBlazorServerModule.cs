using Volo.Abp.Modularity;

namespace BasicManagement.Blazor.Server
{
    [DependsOn(
        typeof(Tchivs.Abp.Blazor.Theme.Bootstrap.Server.TchivsAbpBlazorThemeBootstrapServerModule),
        typeof(BasicManagementBlazorModule)
        )]
    public class BasicManagementBlazorServerModule : AbpModule
    {
        
    }
}