using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SystemManagement.IdentityServer.Dtos;
using SystemManagement.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.IdentityServer.ApiResources;
namespace SystemManagement.IdentityServer.ApiResources
{
    [Authorize(Policy = SystemManagementPermissions.IdentityServer.ApiResource.Default)]
    public class ApiResourceAppService : SystemManagementAppService, IApiResourceAppService
    {
        private readonly IdenityServerApiResourceManager _idenityServerApiResourceManager;

        public ApiResourceAppService(IdenityServerApiResourceManager idenityServerApiResourceManager)
        {
            _idenityServerApiResourceManager = idenityServerApiResourceManager;
        }

        public async Task<PagedResultDto<ApiResourceOutput>> GetListAsync(PagingApiRseourceListInput input)
        {
            var list = await _idenityServerApiResourceManager.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Filter,
                true);
            var totalCount = await _idenityServerApiResourceManager.GetCountAsync(input.Filter);
            return new PagedResultDto<ApiResourceOutput>(totalCount,
                ObjectMapper.Map<List<ApiResource>, List<ApiResourceOutput>>(list));
        }

        /// <summary>
        /// 获取所有api resource
        /// </summary>
        /// <returns></returns>
        public async Task<List<ApiResourceOutput>> GetApiResources()
        {
            var list = await _idenityServerApiResourceManager.GetResources(false);
            return ObjectMapper.Map<List<ApiResource>, List<ApiResourceOutput>>(list);
        }

        /// <summary>
        /// 新增 ApiResource
        /// </summary>
        /// <returns></returns>
        [Authorize(Policy = SystemManagementPermissions.IdentityServer.ApiResource.Create)]
        public Task CreateAsync(CreateApiResourceInput input)
        {
            return _idenityServerApiResourceManager.CreateAsync(
                GuidGenerator.Create(),
                input.Name,
                input.DisplayName,
                input.Description,
                input.Enabled,
                input.AllowedAccessTokenSigningAlgorithms,
                input.ShowInDiscoveryDocument,
                input.Secret
            );
        }

        /// <summary>
        /// 删除 ApiResource
        /// </summary>
        /// <returns></returns>
        [Authorize(Policy = SystemManagementPermissions.IdentityServer.ApiResource.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _idenityServerApiResourceManager.DeleteAsync(id);
        }

        /// <summary>
        /// 更新 ApiResource
        /// </summary>
        /// <returns></returns>
        [Authorize(Policy = SystemManagementPermissions.IdentityServer.ApiResource.Update)]
        public Task UpdateAsync(Guid id,UpdateApiResourceInput input)
        {
            return _idenityServerApiResourceManager.UpdateAsync(id,
                input.DisplayName,
                input.Description,
                input.Enabled,
                input.AllowedAccessTokenSigningAlgorithms,
                input.ShowInDiscoveryDocument,
                input.Secret,
                input.ApiScopes
            );
        }
    }
}