using System.Linq;
using AutoMapper;
using SystemManagement.IdentityServer.ApiScopes.Dtos;
using SystemManagement.IdentityServer.Clients;
using SystemManagement.IdentityServer.Dtos;
using SystemManagement.IdentityServer.IdentityResources.Dtos;
using Volo.Abp.IdentityServer.ApiResources;
using Volo.Abp.IdentityServer.ApiScopes;
using Volo.Abp.IdentityServer.Clients;
using Volo.Abp.IdentityServer.Devices;
using Volo.Abp.IdentityServer.IdentityResources;

namespace SystemManagement.IdentityServer.Mappers
{
    public class IdentityServerApplicationAutoMapperProfile : Profile
    {
        public IdentityServerApplicationAutoMapperProfile()
        {
            CreateMap<ApiResource, ApiResourceOutput>()
                .ForMember(x => x.Scopes,
                map =>
                    map.MapFrom(r => r.Scopes.Select(s => s.Scope)
                        .ToList()))
              
                .ForMember(x=>x.UserClaims,
                    map=>map.MapFrom(r=>r.UserClaims.Select(x=>x.Type)));
            CreateMap<ApiResourceProperty, ApiResourcePropertyOutput>();
            CreateMap<ApiResourceSecret, ApiResourceSecretOutput>();

            CreateMap<Client, PagingClientListOutput>()
                .ForMember(x => x.AllowedGrantTypes,
                    map => map.MapFrom(x =>
                        x.AllowedGrantTypes.Select(t => t.GrantType).ToArray()));
            CreateMap<ClientClaim, ClientClaimOutput>();
            CreateMap<ClientCorsOrigin, ClientCorsOriginOutput>();
            //   CreateMap<ClientGrantType, ClientGrantTypeOutput>();
            CreateMap<ClientIdPRestriction, ClientIdPRestrictionOutput>();
            CreateMap<ClientPostLogoutRedirectUri, ClientPostLogoutRedirectUriOutput>();
            CreateMap<ClientProperty, ClientPropertyOutput>();
            CreateMap<ClientRedirectUri, ClientRedirectUriOutput>();
            CreateMap<ClientScope, ClientScopeOutput>();
            CreateMap<ClientSecret, ClientSecretOutput>();


            CreateMap<ApiScope, PagingApiScopeListOutput>();
            CreateMap<IdentityResource, PagingIdentityResourceListOutput>();
        }
    }
}