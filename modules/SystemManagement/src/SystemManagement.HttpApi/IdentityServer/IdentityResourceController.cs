using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using SystemManagement.IdentityServer.IdentityResources;
using SystemManagement.IdentityServer.IdentityResources.Dtos;
using SystemManagement.Permissions;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SystemManagement.IdentityServer
{
    [Route("api/system/identity-server/")]
    [Area("system")]
    [ControllerName("IdentityServer")]
    [RemoteService(Name=SystemManagementRemoteServiceConsts.RemoteServiceName)]
    public class IdentityServerController : SystemManagementController
    {
        
    }
    [Route("api/system/identity-server/identity-resource")]
    [Area("system")]
    [ControllerName("IdentityResource")]
    [RemoteService(Name=SystemManagementRemoteServiceConsts.RemoteServiceName)]
    public class IdentityResourceController : SystemManagementController,IIdentityResourceAppService
    {
        private readonly IIdentityResourceAppService _identityResourceAppService;

        public IdentityResourceController(IIdentityResourceAppService identityResourceAppService)
        {
            _identityResourceAppService = identityResourceAppService;
        }

        [HttpGet]
        [SwaggerOperation(summary: "分页获取IdentityResource信息", Tags = new[] {"IdentityResource"})]
        public Task<PagedResultDto<PagingIdentityResourceListOutput>> GetListAsync(
            PagingIdentityResourceListInput input)
        {
            return _identityResourceAppService.GetListAsync(input);
        }
        [HttpGet("all")]
        [SwaggerOperation(summary: "获取所有IdentityResource信息", Tags = new[] {"IdentityResource"})]
        public Task<List<PagingIdentityResourceListOutput>> GetAllAsync()
        {
            return _identityResourceAppService.GetAllAsync();
        }

        [HttpPost()]
        [SwaggerOperation(summary: "创建IdentityResource", Tags = new[] {"IdentityResource"})]
        public Task CreateAsync(CreateIdentityResourceInput input)
        {
            return _identityResourceAppService.CreateAsync(input);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(summary: "更新IdentityResource", Tags = new[] {"IdentityResource"})]
        public Task UpdateAsync([Required]Guid id,UpdateIdentityResourceInput input)
        {
            return _identityResourceAppService.UpdateAsync(id,input);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(summary: "删除IdentityResource", Tags = new[] {"IdentityResource"})]
        public Task DeleteAsync(Guid id)
        {
            return _identityResourceAppService.DeleteAsync(id);
        }
    }
}