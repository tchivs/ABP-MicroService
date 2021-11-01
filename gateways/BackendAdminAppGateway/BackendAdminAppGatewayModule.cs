using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Basic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using StackExchange.Redis;
using Microsoft.OpenApi.Models;
using Micro.Shared;
using Swashbuckle.AspNetCore.Swagger;
using Volo.Abp;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.FeatureManagement;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Http.Client.IdentityModel.Web;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.IdentityServer;
using Volo.Abp.Security.Claims;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Cors;
using Volo.Abp.Localization;
namespace BackendAdminAppGateway
{
    [DependsOn(
       typeof(AbpAutofacModule),
       typeof(AbpIdentityHttpApiModule),
       typeof(AbpIdentityHttpApiClientModule),
       typeof(Basic.BasicHttpApiModule),
        typeof(SystemManagement.SystemManagementHttpApiModule),
       typeof(AbpEntityFrameworkCoreSqlServerModule),
       typeof(AbpPermissionManagementEntityFrameworkCoreModule),
       typeof(AbpPermissionManagementApplicationModule),
       typeof(AbpPermissionManagementHttpApiModule),
       typeof(AbpSettingManagementEntityFrameworkCoreModule),
       typeof(AbpPermissionManagementDomainIdentityModule),
       typeof(AbpPermissionManagementDomainIdentityServerModule),
       typeof(AbpHttpClientIdentityModelWebModule),
       typeof(AbpTenantManagementApplicationContractsModule),
       typeof(AbpTenantManagementHttpApiModule),
       typeof(AbpTenantManagementHttpApiClientModule),
       typeof(AbpTenantManagementEntityFrameworkCoreModule),
       typeof(AbpFeatureManagementEntityFrameworkCoreModule),
       typeof(AbpFeatureManagementApplicationModule),
       typeof(AbpFeatureManagementHttpApiModule),
       typeof(AbpAspNetCoreMvcUiMultiTenancyModule)
   )]
    internal class BackendAdminAppGatewayModule : AbpModule
    {

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            Configure<AbpMultiTenancyOptions>(options =>
            {
                options.IsEnabled = Micro.Shared.MicroConsts.IsMultiTenancyEnabled;
            });
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("en", "en", "English"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文"));
            });
            context.Services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.ApiName = configuration["AuthServer:ApiName"];
                    options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                });
            ConfigureCors(context, configuration);
            ConfigureSwaggerServices(context, configuration);

            context.Services.AddOcelot(context.Services.GetConfiguration());

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });

            context.Services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration["Redis:Configuration"];
            });

            var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
            context.Services.AddDataProtection()
                .PersistKeysToStackExchangeRedis(redis, "MsDemo-DataProtection-Keys");
        }
        private static void ConfigureSwaggerServices(ServiceConfigurationContext context, IConfiguration configuration)
        {

            //await CreateApiScopeAsync("IdentityService");
            //await CreateApiScopeAsync("TenantManagementService");
            //await CreateApiScopeAsync("BloggingService");
            //await CreateApiScopeAsync("ProductService");
            //await CreateApiScopeAsync("BasicService");
            //await CreateApiScopeAsync("LaborService");
            //await CreateApiScopeAsync("InternalGateway");
            //await CreateApiScopeAsync("BackendAdminAppGateway");
            //await CreateApiScopeAsync("PublicWebSiteGateway");

            context.Services.AddAbpSwaggerGenWithOAuth(
                configuration["AuthServer:Authority"],
                new Dictionary<string, string>
                {
                    {"IdentityService", "IdentityService API"},
                    {"TenantService", "TenantService API"},
                    {"BasicService", "BasicService API"},
                    {"SystemService","SystemService API" },
                    {"BackendAdminAppGateway", "BackendAdminAppGateway API"},

                },
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "BackendAdminApp Gateway API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                });
        }

        private void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .WithOrigins(
                            configuration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                         .WithAbpExposedHeaders()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                    .AllowCredentials();
                });
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var configuration = context.GetConfiguration();

            app.UseCorrelationId();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAbpClaimsMap();

            if (MicroConsts.IsMultiTenancyEnabled)
            {
                app.UseMultiTenancy();
            }
            app.UseAbpRequestLocalization();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "BackendAdminApp Gateway API");
                options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
                options.OAuthClientSecret(configuration["AuthServer:SwaggerClientSecret"]);
                options.OAuthScopes("Basic");
            });

            app.MapWhen(
                ctx => ctx.Request.Path.ToString().StartsWith("/api/abp/") ||
                       ctx.Request.Path.ToString().StartsWith("/Abp/") ||
                       ctx.Request.Path.ToString().StartsWith("/api/permission-management/") ||
                       ctx.Request.Path.ToString().StartsWith("/api/feature-management/"),
                app2 =>
                {
                    app2.UseRouting();
                    app2.UseConfiguredEndpoints();
                }
            );
            app.UseOcelot()
                .Wait();
            // app.UseConfiguredEndpoints();

        }

    }
}