using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace BasicManagement.Blazor.Server
{
    [DependsOn(
        typeof(AbpAspNetCoreComponentsServerThemingModule),
        typeof(BasicManagementBlazorModule)
        )]
    public class BasicManagementBlazorServerModule : AbpModule
    {
        
    }
}