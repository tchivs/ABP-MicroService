using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using SystemManagement.IdentityServer.ApiScopes;
using SystemManagement.IdentityServer.ApiScopes.Dtos;
using SystemManagement.Permissions;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SystemManagement.IdentityServer
{
    [Route("api/system/identity-server/api-scope")]
    [Area("system")]
    [ControllerName("ApiScope")] 
    [RemoteService(Name=SystemManagementRemoteServiceConsts.RemoteServiceName)] public class ApiScopeController:SystemManagementController,IApiScopeAppService
    {
        private readonly IApiScopeAppService _apiScopeAppService;

        public ApiScopeController(IApiScopeAppService apiScopeAppService)
        {
            _apiScopeAppService = apiScopeAppService;
        }

        [HttpGet]
        [SwaggerOperation(summary: "分页获取ApiScope信息", Tags = new[] {"ApiScope"})]
        public Task<PagedResultDto<PagingApiScopeListOutput>> GetListAsync(PagingApiScopeListInput input)
        {
            return _apiScopeAppService.GetListAsync(input);
        }

        [HttpPost()]
        [SwaggerOperation(summary: "创建ApiScope", Tags = new[] {"ApiScope"})]
        public Task CreateAsync(CreateApiScopeInput input)
        {
            return _apiScopeAppService.CreateAsync(input);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(summary: "更新ApiScope", Tags = new[] {"ApiScope"})]
        public Task UpdateAsync(Guid id,UpdateCreateApiScopeInput input)
        {
            return _apiScopeAppService.UpdateAsync(id,input);
        }

        [HttpDelete("{id}")]

        [SwaggerOperation(summary: "删除ApiScope", Tags = new[] {"ApiScope"})]
        public Task DeleteAsync(Guid id)
        {
            return _apiScopeAppService.DeleteAsync(id);
        }
        [HttpGet("all")]
        [SwaggerOperation(summary: "获取所有ApiScope", Tags = new[] {"ApiScope"})]
        public  Task<List<KeyValuePair<string, string>>> FindAllAsync()
        {
            return _apiScopeAppService.FindAllAsync();
        }
    }
}