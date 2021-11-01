using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer.ApiResources;
using Volo.Abp.IdentityServer.ApiScopes;
using Volo.Abp.IdentityServer.Clients;
using Volo.Abp.IdentityServer.IdentityResources;
using Volo.Abp.PermissionManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.Uow;
using ApiResource = Volo.Abp.IdentityServer.ApiResources.ApiResource;
using Client = Volo.Abp.IdentityServer.Clients.Client;

namespace AuthServer
{
    public class AuthServerDataSeeder : IDataSeedContributor, ITransientDependency
    {
        private readonly IApiResourceRepository _apiResourceRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IApiScopeRepository _apiScopeRepository;
        private readonly IIdentityResourceDataSeeder _identityResourceDataSeeder;
        private readonly IGuidGenerator _guidGenerator;
        private readonly IPermissionDataSeeder _permissionDataSeeder;

        public AuthServerDataSeeder(
            IClientRepository clientRepository,
            IApiResourceRepository apiResourceRepository,
            IIdentityResourceDataSeeder identityResourceDataSeeder,
            IGuidGenerator guidGenerator,
            IPermissionDataSeeder permissionDataSeeder,
            IApiScopeRepository apiScopeRepository)
        {
            _clientRepository = clientRepository;
            _apiResourceRepository = apiResourceRepository;
            _identityResourceDataSeeder = identityResourceDataSeeder;
            _guidGenerator = guidGenerator;
            _permissionDataSeeder = permissionDataSeeder;
            _apiScopeRepository = apiScopeRepository;
        }

        [UnitOfWork]
        public virtual async Task SeedAsync(DataSeedContext context)
        {
            await _identityResourceDataSeeder.CreateStandardResourcesAsync();
            await CreateApiScopesAsync();
            await CreateApiResourcesAsync();
            await CreateClientsAsync();
        }

        private async Task CreateApiScopesAsync()
        {
            await CreateApiScopeAsync("IdentityService");
            await CreateApiScopeAsync("TenantService");
            await CreateApiScopeAsync("BasicService");
            await CreateApiScopeAsync("SystemService");
            await CreateApiScopeAsync("LaborService");
            await CreateApiScopeAsync("InternalGateway");
            await CreateApiScopeAsync("BackendAdminAppGateway");
            await CreateApiScopeAsync("PublicWebSiteGateway");
        }

        private async Task<ApiScope> CreateApiScopeAsync(string name)
        {
            var apiScope = await _apiScopeRepository.GetByNameAsync(name);
            if (apiScope == null)
            {
                apiScope = await _apiScopeRepository.InsertAsync(
                    new ApiScope(
                        _guidGenerator.Create(),
                        name,
                        name + " API"
                    ),
                    autoSave: true
                );
            }

            return apiScope;
        }

        private async Task CreateApiResourcesAsync()
        {
            var commonApiUserClaims = new[]
            {
                "email",
                "email_verified",
                "name",
                "phone_number",
                "phone_number_verified",
                "role"
            };
            await CreateApiResourceAsync("IdentityService", commonApiUserClaims);
            await CreateApiResourceAsync("TenantService", commonApiUserClaims);
            await CreateApiResourceAsync("LaborService", commonApiUserClaims);
            await CreateApiResourceAsync("SystemService", commonApiUserClaims);
            await CreateApiResourceAsync("BasicService", commonApiUserClaims);
            await CreateApiResourceAsync("InternalGateway", commonApiUserClaims);
            await CreateApiResourceAsync("BackendAdminAppGateway", commonApiUserClaims);
            await CreateApiResourceAsync("PublicWebSiteGateway", commonApiUserClaims);
        }

        private async Task<ApiResource> CreateApiResourceAsync(string name, IEnumerable<string> claims)
        {
            var apiResource = await _apiResourceRepository.FindByNameAsync(name);
            if (apiResource == null)
            {
                apiResource = await _apiResourceRepository.InsertAsync(
                    new ApiResource(
                        _guidGenerator.Create(),
                        name,
                        name + " API"
                    ),
                    autoSave: true
                );
            }

            foreach (var claim in claims)
            {
                if (apiResource.FindClaim(claim) == null)
                {
                    apiResource.AddUserClaim(claim);
                }
            }

            return await _apiResourceRepository.UpdateAsync(apiResource);
        }

        private async Task CreateClientsAsync()
        {
            const string commonSecret = "E5Xd4yMqjP5kjWFKrYgySBju6JVfCzMyFp7n2QmMrME=";

            var commonScopes = new[]
            {
                "email",
                "openid",
                "profile",
                "role",
                "phone",
                "address"
            };
            var adminScope = commonScopes.Union(new[]
            {
                "BackendAdminAppGateway",
                "IdentityService",
                "TenantService",
                "LaborService",
                "BasicService",
                "SystemService"
            }).ToArray();

            //await CreateClientAsync(
            //    "console-client-demo",
            //    new[] { "BloggingService", "IdentityService", "InternalGateway", "ProductService", "TenantManagementService", "LaborService", "BasicService" },
            //    new[] { "client_credentials", "password" },
            //    commonSecret,
            //    permissions: new[] { IdentityPermissions.Users.Default, TenantManagementPermissions.Tenants.Default, "ProductManagement.Product" }
            //);

            //await CreateClientAsync(
            //    "backend-admin-app-client",
            //  adminScope,
            //    new[] { "hybrid" },
            //    commonSecret,
            //    permissions: new[] { IdentityPermissions.Users.Default, "ProductManagement.Product" },
            //    redirectUri: "https://localhost:44354/signin-oidc",
            //    postLogoutRedirectUri: "https://localhost:44354/signout-callback-oidc"
            //);

            //await CreateClientAsync(
            //    "public-website-client",
            //    commonScopes.Union(new[] { "PublicWebSiteGateway", "BloggingService", "ProductService", "LaborService", "BasicService" }),
            //    new[] { "hybrid" },
            //    commonSecret,
            //    redirectUri: "https://localhost:44335/signin-oidc",
            //    postLogoutRedirectUri: "https://localhost:44335/signout-callback-oidc"
            //);

            //await CreateClientAsync(
            //    "blogging-service-client",
            //    new[] { "InternalGateway", "IdentityService", "BasicService" },
            //    new[] { "client_credentials" },
            //    commonSecret,
            //    permissions: new[] { IdentityPermissions.UserLookup.Default }
            //);
            // Swagger Client
            var swaggerRootUrl = "https://localhost:3005";
            await CreateClientAsync(
                name: "Gateway_Swagger",
                scopes: adminScope,
                grantTypes: new[] {"authorization_code"},
                secret: commonSecret,
                requireClientSecret: false,
                redirectUri: $"{swaggerRootUrl}/swagger/oauth2-redirect.html",
                corsOrigins: new[] {swaggerRootUrl.RemovePostFix("/")}
            );
            // Blazor WebAssembly Client
            var blazorAdminRootUrl = "https://localhost:3010";
            await CreateClientAsync(
                name: "backend-admin-app-blazor-webAssembly-client",
                scopes: adminScope,
                grantTypes: new[] {"authorization_code"},
                secret: commonSecret,
                requireClientSecret: false,
                redirectUri: $"{blazorAdminRootUrl}/authentication/login-callback",
                postLogoutRedirectUri: $"{blazorAdminRootUrl}/authentication/logout-callback",
                corsOrigins: new[] {blazorAdminRootUrl}
            );

            //Blazor Server Tiered Client
            var blazorServerRootUrl = "https://localhost:3009";
            await CreateClientAsync(
                name: "backend-admin-app-blazor-server-client",
                scopes: adminScope,
                new[] {"hybrid"},
                commonSecret,
                redirectUri: $"{blazorServerRootUrl}/signin-oidc",
                postLogoutRedirectUri: $"{blazorServerRootUrl}/signout-callback-oidc",
                frontChannelLogoutUri: $"{blazorServerRootUrl}/Account/FrontChannelLogout",
                corsOrigins: new[] {blazorServerRootUrl.RemovePostFix("/")}
            );
        }

        private async Task<Client> CreateClientAsync(
            string name,
            IEnumerable<string> scopes,
            IEnumerable<string> grantTypes,
            string secret,
            string redirectUri = null,
            string postLogoutRedirectUri = null,
            bool requireClientSecret = true,
            string frontChannelLogoutUri = null,
            IEnumerable<string> permissions = null,
            IEnumerable<string> corsOrigins = null)
        {
            var client = await _clientRepository.FindByClientIdAsync(name);
            if (client == null)
            {
                client = await _clientRepository.InsertAsync(
                    new Client(
                        _guidGenerator.Create(),
                        name
                    )
                    {
                        ClientName = name,
                        ProtocolType = "oidc",
                        Description = name,
                        AlwaysIncludeUserClaimsInIdToken = true,
                        AllowOfflineAccess = true,
                        AbsoluteRefreshTokenLifetime = 31536000, //365 days
                        AccessTokenLifetime = 31536000, //365 days
                        AuthorizationCodeLifetime = 300,
                        IdentityTokenLifetime = 300,
                        FrontChannelLogoutUri = frontChannelLogoutUri,
                        RequireConsent = false,
                        RequireClientSecret = requireClientSecret,
                        RequirePkce = false
                    },
                    autoSave: true
                );
            }

            foreach (var scope in scopes)
            {
                if (client.FindScope(scope) == null)
                {
                    client.AddScope(scope);
                }
            }

            foreach (var grantType in grantTypes)
            {
                if (client.FindGrantType(grantType) == null)
                {
                    client.AddGrantType(grantType);
                }
            }

            if (client.FindSecret(secret) == null)
            {
                client.AddSecret(secret);
            }

            if (redirectUri != null)
            {
                if (client.FindRedirectUri(redirectUri) == null)
                {
                    client.AddRedirectUri(redirectUri);
                }
            }

            if (postLogoutRedirectUri != null)
            {
                if (client.FindPostLogoutRedirectUri(postLogoutRedirectUri) == null)
                {
                    client.AddPostLogoutRedirectUri(postLogoutRedirectUri);
                }
            }

            if (permissions != null)
            {
                await _permissionDataSeeder.SeedAsync(
                    ClientPermissionValueProvider.ProviderName,
                    name,
                    permissions
                );
            }

            if (corsOrigins != null)
            {
                foreach (var origin in corsOrigins)
                {
                    if (!origin.IsNullOrWhiteSpace() && client.FindCorsOrigin(origin) == null)
                    {
                        client.AddCorsOrigin(origin);
                    }
                }
            }

            return await _clientRepository.UpdateAsync(client);
        }
    }
}