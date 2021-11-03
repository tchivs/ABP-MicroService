﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using SystemManagement.IdentityServer.IdentityResources;
using SystemManagement.IdentityServer.IdentityResources.Dtos;
using SystemManagement.Permissions;
using Volo.Abp.Application.Dtos;

namespace SystemManagement.IdentityServer
{
    [Route("api/system/IdentityServer/IdentityResource")]
    public class IdentityResourceController : SystemManagementController
    {
        private readonly IIdentityResourceAppService _identityResourceAppService;

        public IdentityResourceController(IIdentityResourceAppService identityResourceAppService)
        {
            _identityResourceAppService = identityResourceAppService;
        }

        [HttpPost("page")]
        [SwaggerOperation(summary: "分页获取IdentityResource信息", Tags = new[] {"IdentityResource"})]
        public Task<PagedResultDto<PagingIdentityResourceListOutput>> GetListAsync(
            PagingIdentityResourceListInput input)
        {
            return _identityResourceAppService.GetListAsync(input);
        }
        [HttpPost("all")]
        [SwaggerOperation(summary: "获取所有IdentityResource信息", Tags = new[] {"IdentityResource"})]
        public Task<List<PagingIdentityResourceListOutput>> GetAllAsync()
        {
            return _identityResourceAppService.GetAllAsync();
        }

        [HttpPost("create")]
        [SwaggerOperation(summary: "创建IdentityResource", Tags = new[] {"IdentityResource"})]
        public Task CreateAsync(CreateIdentityResourceInput input)
        {
            return _identityResourceAppService.CreateAsync(input);
        }

        [HttpPost("update")]
        [SwaggerOperation(summary: "更新IdentityResource", Tags = new[] {"IdentityResource"})]
        public Task UpdateAsync(UpdateIdentityResourceInput input)
        {
            return _identityResourceAppService.UpdateAsync(input);
        }

        [HttpPost("delete")]
        [SwaggerOperation(summary: "删除IdentityResource", Tags = new[] {"IdentityResource"})]
        public Task DeleteAsync(Guid input)
        {
            return _identityResourceAppService.DeleteAsync(input);
        }
    }
}