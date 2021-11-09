using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SystemManagement.IdentityServer;
using SystemManagement.IdentityServer.IdentityResources;
using SystemManagement.IdentityServer.IdentityResources.Dtos;
using SystemManagement.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.IdentityServer.IdentityResources;

namespace SystemManagement.IdentityServer.Mappers.IdentityResources
{
    [Authorize(Policy = SystemManagementPermissions.IdentityServer.IdentityResources.Default)]
    public class IdentityResourceAppService :
        CrudAppService<IdentityResource, PagingIdentityResourceListOutput, Guid, PagingIdentityResourceListInput,
            CreateIdentityResourceInput, UpdateIdentityResourceInput>, IIdentityResourceAppService
    {
        private readonly IdentityResourceManager _identityResourceManager;

        public IdentityResourceAppService(IdentityResourceManager identityResourceManager,
            IRepository<IdentityResource, Guid> repository) : base(repository)
        {
            _identityResourceManager = identityResourceManager;
        }


        public async Task<List<PagingIdentityResourceListOutput>> GetAllAsync()
        {
            var list = await _identityResourceManager.GetAllAsync();
            return ObjectMapper.Map<List<IdentityResource>, List<PagingIdentityResourceListOutput>>(list);
        }


        protected override string GetPolicyName { get; set; } =
            SystemManagementPermissions.IdentityServer.IdentityResources.Default;

        protected override string UpdatePolicyName { get; set; } =
            SystemManagementPermissions.IdentityServer.IdentityResources.Update;

        protected override string DeletePolicyName { get; set; } =
            SystemManagementPermissions.IdentityServer.IdentityResources.Delete;

        protected override string CreatePolicyName { get; set; } =
            SystemManagementPermissions.IdentityServer.IdentityResources.Create;
    }
}