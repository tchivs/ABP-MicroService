using AutoMapper;
using System.Linq;
using SystemManagement.IdentityServer.ApiScopes.Dtos;
using SystemManagement.IdentityServer.Dtos;
using SystemManagement.IdentityServer.IdentityResources.Dtos;

namespace SystemManagement.Blazor
{
    public class SystemManagementBlazorAutoMapperProfile : Profile
    {
        public SystemManagementBlazorAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<PagingApiScopeListOutput, CreateApiScopeInput>();
            CreateMap<PagingApiScopeListOutput, UpdateCreateApiScopeInput>();
            CreateMap<ApiResourceOutput, CreateApiResourceInput>().ForMember(x=>x.Secret,m=>m.MapFrom(x=>x.Secrets.FirstOrDefault().Value));
            CreateMap<ApiResourceOutput, UpdateApiResourceInput>().ForMember(x => x.Secret, m => m.MapFrom(x => x.Secrets.FirstOrDefault().Value));

            CreateMap<PagingIdentityResourceListOutput, CreateIdentityResourceInput>();
            CreateMap<PagingIdentityResourceListOutput, UpdateIdentityResourceInput>();
        }
    }
}