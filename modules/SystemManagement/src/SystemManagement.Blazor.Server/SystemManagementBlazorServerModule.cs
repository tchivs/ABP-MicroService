using Volo.Abp.Modularity;

namespace SystemManagement.Blazor.Server
{
    [DependsOn(
        typeof(Tchivs.Abp.Blazor.Theme.Bootstrap.Server.TchivsAbpBlazorThemeBootstrapServerModule),
        typeof(SystemManagementBlazorModule)
        )]
    public class SystemManagementBlazorServerModule : AbpModule
    {
        
    }
}