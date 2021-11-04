﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SystemManagement.IdentityServer;
using SystemManagement.IdentityServer.IdentityResources;
using SystemManagement.IdentityServer.IdentityResources.Dtos;
using SystemManagement.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.IdentityServer.IdentityResources;

namespace SystemManagement.IdentityServer.Mappers.IdentityResources
{
    [Authorize(Policy = SystemManagementPermissions.IdentityServer.IdentityResources.Default)]

    public class IdentityResourceAppService : SystemManagementAppService, IIdentityResourceAppService
    {
        private readonly IdentityResourceManager _identityResourceManager;

        public IdentityResourceAppService(IdentityResourceManager identityResourceManager)
        {
            _identityResourceManager = identityResourceManager;
        }

        /// <summary>
        /// 分页获取IdentityResource
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<PagedResultDto<PagingIdentityResourceListOutput>> GetListAsync(
            PagingIdentityResourceListInput input)
        {
            var list = await _identityResourceManager.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Filter,
                true);
            var totalCount = await _identityResourceManager.GetCountAsync(input.Filter);
            return new PagedResultDto<PagingIdentityResourceListOutput>(totalCount,
                ObjectMapper.Map<List<IdentityResource>, List<PagingIdentityResourceListOutput>>(list));
        }

        public async Task<List<PagingIdentityResourceListOutput>> GetAllAsync()
        {
            var list = await _identityResourceManager.GetAllAsync();
            return ObjectMapper.Map<List<IdentityResource>, List<PagingIdentityResourceListOutput>>(list);
        }

        /// <summary>
        /// 创建IdentityResource
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(Policy = SystemManagementPermissions.IdentityServer.IdentityResources.Create)]
        public Task CreateAsync(CreateIdentityResourceInput input)
        {
            return _identityResourceManager.CreateAsync(input.Name, input.DisplayName, input.Description,
                input.Enabled, input.Required, input.Emphasize, input.ShowInDiscoveryDocument);
        }

        /// <summary>
        /// 更新IdentityResource
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(Policy = SystemManagementPermissions.IdentityServer.IdentityResources.Update)]
        public Task UpdateAsync(Guid id,UpdateIdentityResourceInput input)
        {
            return _identityResourceManager.UpdateAsync(id,input.Name, input.DisplayName, input.Description,
                input.Enabled, input.Required, input.Emphasize, input.ShowInDiscoveryDocument);
        }

        /// <summary>
        /// 删除IdentityResource
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [Authorize(Policy = SystemManagementPermissions.IdentityServer.IdentityResources.Delete)]
        public Task DeleteAsync(Guid id)
        {
            return _identityResourceManager.DeleteAsync(id);
        }
    }
}