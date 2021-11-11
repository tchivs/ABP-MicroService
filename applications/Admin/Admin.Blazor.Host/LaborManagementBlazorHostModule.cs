using System;
using System.Net.Http;
using IdentityModel;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tchivs.Abp.Blazor.Routing;
using Tchivs.Abp.Blazor.Theme.Bootstrap.Components;
using Tchivs.Abp.Blazor.Theme.Bootstrap.WebAssembly;
using Volo.Abp.Account;
using Volo.Abp.Autofac;
using Volo.Abp.Autofac.WebAssembly;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.UI.Navigation;

namespace Admin.Blazor.Host
{
    [DependsOn(
        typeof(TchivsAbpBlazorThemeBootstrapWebAssembly),
        typeof(Admin.Blazor.AdminBlazorModule),
        typeof(AbpIdentityApplicationContractsModule),
        typeof(AbpAutofacWebAssemblyModule),
        typeof(AbpAccountApplicationContractsModule),
        // typeof(AbpIdentityBlazorWebAssemblyModule),
        // typeof(AbpTenantManagementBlazorWebAssemblyModule),
        // typeof(AbpFeatureManagementBlazorWebAssemblyModule),
        // typeof(AbpSettingManagementBlazorWebAssemblyModule),
        typeof(AbpIdentityHttpApiClientModule),
        typeof(AbpFeatureManagementHttpApiClientModule),
        typeof(AbpTenantManagementHttpApiClientModule),
        typeof(AbpPermissionManagementHttpApiClientModule),
        typeof(AbpAutofacModule)
    )]
    public class AdminBlazorHostModule : AbpModule
    {
    
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var environment = context.Services.GetSingletonInstance<IWebAssemblyHostEnvironment>();
            var builder = context.Services.GetSingletonInstance<WebAssemblyHostBuilder>();

            ConfigureAuthentication(builder);
            ConfigureHttpClient(context, environment);
            
            ConfigureRouter(context);
            ConfigureUI(builder);
            ConfigureMenu(context);
            ConfigureAutoMapper(context);
        }

        private void ConfigureRouter(ServiceConfigurationContext context)
        {
            Configure<AbpRouterOptions>(options => { options.AppAssembly = typeof(AdminBlazorHostModule).Assembly; });
        }

        private void ConfigureMenu(ServiceConfigurationContext context)
        {
            Configure<AbpNavigationOptions>(options =>
            {
                options.MenuContributors.Add(new AdminHostMenuContributor(context.Services.GetConfiguration()));
            });
        }

      

        private static void ConfigureAuthentication(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddOidcAuthentication(options =>
            {
                builder.Configuration.Bind("AuthServer", options.ProviderOptions);
                options.UserOptions.RoleClaim = JwtClaimTypes.Role;
                options.ProviderOptions.DefaultScopes.Add("role");
                options.ProviderOptions.DefaultScopes.Add("email");
                options.ProviderOptions.DefaultScopes.Add("phone");
                options.ProviderOptions.DefaultScopes.Add("SystemService");
                options.ProviderOptions.DefaultScopes.Add("BackendAdminAppGateway");
                options.ProviderOptions.DefaultScopes.Add("IdentityService");
                options.ProviderOptions.DefaultScopes.Add("TenantService");
            });
        }

        private static void ConfigureUI(WebAssemblyHostBuilder builder)
        {
            builder.RootComponents.Add<App>("#ApplicationContainer");
        }

        private static void ConfigureHttpClient(ServiceConfigurationContext context,
            IWebAssemblyHostEnvironment environment)
        {
            context.Services.AddTransient(sp => new HttpClient
            {
                BaseAddress = new Uri(environment.BaseAddress)
            });
        }

        private void ConfigureAutoMapper(ServiceConfigurationContext context)
        {
            Configure<AbpAutoMapperOptions>(options => { options.AddMaps<AdminBlazorHostModule>(); });
        }
    }
}