using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using SystemManagement.IdentityServer.Dtos;
using SystemManagement.Permissions;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SystemManagement.IdentityServer
{
    [Route("api/system/identity-server/api-resource")]
    [Area("system")]
    [ControllerName("ApiResource")]
    [RemoteService(Name=SystemManagementRemoteServiceConsts.RemoteServiceName)]
    public class ApiResourceController : SystemManagementController, IApiResourceAppService
    {
        private readonly IApiResourceAppService _apiResourceAppService;

        public ApiResourceController(IApiResourceAppService apiResourceAppService)
        {
            _apiResourceAppService = apiResourceAppService;
        }

        [HttpGet()]
        [SwaggerOperation(summary: "分页获取ApiResource信息", Tags = new[] {"ApiResource"})]
        public Task<PagedResultDto<ApiResourceOutput>> GetListAsync(PagingApiRseourceListInput input)
        {
            return _apiResourceAppService.GetListAsync(input);
        }


        [HttpGet("all")]
        [SwaggerOperation(summary: "获取ApiResource信息", Tags = new[] {"ApiResource"})]
        public Task<List<ApiResourceOutput>> GetApiResources()
        {
            return _apiResourceAppService.GetApiResources();
        }

        [HttpPost()]
        [SwaggerOperation(summary: "新增ApiResource", Tags = new[] {"ApiResource"})]
        public Task CreateAsync(CreateApiResourceInput input)
        {
            return _apiResourceAppService.CreateAsync(input);
        }


        [HttpDelete("{id}")]
        [SwaggerOperation(summary: "删除ApiResource", Tags = new[] {"ApiResource"})]
        public async Task DeleteAsync(Guid id)
        {
            await _apiResourceAppService.DeleteAsync(id);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(summary: "修改ApiResource", Tags = new[] {"ApiResource"})]
        public Task UpdateAsync(Guid id,UpdateApiResourceInput input)
        {
            return _apiResourceAppService.UpdateAsync(id,input);
        }
    }
}