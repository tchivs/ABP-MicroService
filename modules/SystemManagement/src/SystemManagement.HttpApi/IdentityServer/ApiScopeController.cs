﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using SystemManagement.IdentityServer.ApiScopes;
using SystemManagement.IdentityServer.ApiScopes.Dtos;
using SystemManagement.Permissions;
using Volo.Abp.Application.Dtos;

namespace SystemManagement.IdentityServer
{
    [Route("api/system/IdentityServer/ApiScope")]
    [Authorize(Policy = SystemManagementPermissions.IdentityServer.ApiScope.Default)]
    public class ApiScopeController:SystemManagementController
    {
        private readonly IApiScopeAppService _apiScopeAppService;

        public ApiScopeController(IApiScopeAppService apiScopeAppService)
        {
            _apiScopeAppService = apiScopeAppService;
        }

        [HttpPost("page")]
        [SwaggerOperation(summary: "分页获取ApiScope信息", Tags = new[] {"ApiScope"})]
        public Task<PagedResultDto<PagingApiScopeListOutput>> GetListAsync(PagingApiScopeListInput input)
        {
            return _apiScopeAppService.GetListAsync(input);
        }

        [HttpPost("create")]
        [SwaggerOperation(summary: "创建ApiScope", Tags = new[] {"ApiScope"})]
        [Authorize(Policy = SystemManagementPermissions.IdentityServer.ApiScope.Create)]
        public Task CreateAsync(CreateApiScopeInput input)
        {
            return _apiScopeAppService.CreateAsync(input);
        }

        [HttpPost("update")]
        [SwaggerOperation(summary: "更新ApiScope", Tags = new[] {"ApiScope"})]
        [Authorize(Policy = SystemManagementPermissions.IdentityServer.ApiScope.Update)]
        public Task UpdateAsync(UpdateCreateApiScopeInput input)
        {
            return _apiScopeAppService.UpdateAsync(input);
        }

        [HttpPost("delete")]
        [SwaggerOperation(summary: "删除ApiScope", Tags = new[] {"ApiScope"})]
        [Authorize(Policy = SystemManagementPermissions.IdentityServer.ApiScope.Delete)]
        public Task DeleteAsync(Guid id)
        {
            return _apiScopeAppService.DeleteAsync(id);
        }
        [HttpPost("all")]
        [SwaggerOperation(summary: "获取所有ApiScope", Tags = new[] {"ApiScope"})]
        public  Task<List<KeyValuePair<string, string>>> FindAllAsync()
        {
            return _apiScopeAppService.FindAllAsync();
        }
    }
}