using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SystemManagement.IdentityServer;
using SystemManagement.IdentityServer.ApiScopes.Dtos;
using SystemManagement.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.IdentityServer.ApiScopes;

namespace SystemManagement.IdentityServer.ApiScopes
{
    [Authorize(Policy = SystemManagementPermissions.IdentityServer.ApiScope.Default)]
    public class ApiScopeAppService : SystemManagementAppService, IApiScopeAppService
    {
        private readonly IdenityServerApiScopeManager _idenityServerApiScopeManager;
        private readonly IdentityResourceManager _identityResourceManager;

        public ApiScopeAppService(IdenityServerApiScopeManager idenityServerApiScopeManager,
            IdentityResourceManager identityResourceManager)
        {
            _idenityServerApiScopeManager = idenityServerApiScopeManager;
            _identityResourceManager = identityResourceManager;
        }

        public async Task<PagedResultDto<PagingApiScopeListOutput>> GetListAsync(PagingApiScopeListInput input)
        {
            var list = await _idenityServerApiScopeManager.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Filter,
                false);
            var totalCount = await _idenityServerApiScopeManager.GetCountAsync(input.Filter);
            return new PagedResultDto<PagingApiScopeListOutput>(totalCount,
                ObjectMapper.Map<List<ApiScope>, List<PagingApiScopeListOutput>>(list));
        }

        [Authorize(Policy = SystemManagementPermissions.IdentityServer.ApiScope.Create)]
        public Task CreateAsync(CreateApiScopeInput input)
        {
            return _idenityServerApiScopeManager.CreateAsync(input.Name, input.DisplayName, input.Description,
                input.Enabled, input.Required, input.Emphasize, input.ShowInDiscoveryDocument);
        }

        [Authorize(Policy = SystemManagementPermissions.IdentityServer.ApiScope.Update)]
        public Task UpdateAsync(Guid id,UpdateCreateApiScopeInput input)
        {
            return _idenityServerApiScopeManager.UpdateAsync(id, input.DisplayName, input.Description,
                input.Enabled, input.Required, input.Emphasize, input.ShowInDiscoveryDocument);
        }

        [Authorize(Policy = SystemManagementPermissions.IdentityServer.ApiScope.Delete)]
        public Task DeleteAsync(Guid id)
        {
            return _idenityServerApiScopeManager.DeleteAsync(id);
        }

        public async Task<List<KeyValuePair<string, string>>> FindAllAsync()
        {
            var result = new List<KeyValuePair<string, string>>();
            var apiScopes = await _idenityServerApiScopeManager.FindAllAsync();
            result.AddRange(apiScopes.Select(e => new KeyValuePair<string, string>(e.Name, e.DisplayName)).ToList());
            var identityResoure = await _identityResourceManager.GetAllAsync();
            result.AddRange(identityResoure.Select(e => new KeyValuePair<string, string>(e.Name, e.DisplayName))
                .ToList());
            return result;
        }
    }
}