using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using SystemManagement.IdentityServer.Dtos;
using SystemManagement.Permissions;
using Volo.Abp.Application.Dtos;

namespace SystemManagement.IdentityServer
{
    [Route("api/system/IdentityServer/ApiResource")]
    [Authorize(Policy = SystemManagementPermissions.IdentityServer.ApiResource.Default)]
    public class ApiResourceController : SystemManagementController
    {
        private readonly IApiResourceAppService _apiResourceAppService;

        public ApiResourceController(IApiResourceAppService apiResourceAppService)
        {
            _apiResourceAppService = apiResourceAppService;
        }

        [HttpPost("page")]
        [SwaggerOperation(summary: "分页获取ApiResource信息", Tags = new[] {"ApiResource"})]
        public Task<PagedResultDto<ApiResourceOutput>> GetListAsync(PagingApiRseourceListInput input)
        {
            return _apiResourceAppService.GetListAsync(input);
        }


        [HttpPost("all")]
        [SwaggerOperation(summary: "获取ApiResource信息", Tags = new[] {"ApiResource"})]
        public Task<List<ApiResourceOutput>> GetApiResources()
        {
            return _apiResourceAppService.GetApiResources();
        }

        [HttpPost("create")]
        [SwaggerOperation(summary: "新增ApiResource", Tags = new[] {"ApiResource"})]
        [Authorize(Policy = SystemManagementPermissions.IdentityServer.ApiResource.Create)]
        public Task CreateAsync(CreateApiResourceInput input)
        {
            return _apiResourceAppService.CreateAsync(input);
        }


        [HttpPost("delete")]
        [SwaggerOperation(summary: "删除ApiResource", Tags = new[] {"ApiResource"})]
        [Authorize(Policy = SystemManagementPermissions.IdentityServer.ApiResource.Delete)]
        public async Task DeleteAsync(Guid input)
        {
            await _apiResourceAppService.DeleteAsync(input);
        }

        [HttpPost("update")]
        [SwaggerOperation(summary: "删除ApiResource", Tags = new[] {"ApiResource"})]
        [Authorize(Policy = SystemManagementPermissions.IdentityServer.ApiResource.Update)]
        public Task UpdateAsync(UpdateApiResourceInput input)
        {
            return _apiResourceAppService.UpdateAsync(input);
        }
    }
}