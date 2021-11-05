using AutoMapper;
using SystemManagement.IdentityServers;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.IdentityServer.ApiResources;
using Volo.Abp.Security.Claims;

namespace SystemManagement
{
    public class SystemManagementApplicationAutoMapperProfile : Profile
    {
        public SystemManagementApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            this.CreateMap<IdentityClaimType, IdentityClaimTypeDto>();
        }
    }
}