using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using SystemManagement.IdentityServer.ApiScopes;
using SystemManagement.IdentityServer.Clients;
using SystemManagement.Permissions;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace SystemManagement.IdentityServer
{
    [Route("api/system/identity-server/client")]
    [Area("system")]
    [ControllerName("Client")]
    [RemoteService(Name = SystemManagementRemoteServiceConsts.RemoteServiceName)]
    public class ClientController : SystemManagementController, IIdentityServerClientAppService
    {
        private readonly IIdentityServerClientAppService _identityServerClientAppService;

        public ClientController(IIdentityServerClientAppService identityServerClientAppService)
        {
            _identityServerClientAppService = identityServerClientAppService;
        }

        [HttpGet()]
        [SwaggerOperation(summary: "分页获取Client信息", Tags = new[] {"Client"})]
        public Task<PagedResultDto<PagingClientListOutput>> GetListAsync(PagingClientListInput input)
        {
            return _identityServerClientAppService.GetListAsync(input);
        }


        [HttpPost()]
        [SwaggerOperation(summary: "创建Client", Tags = new[] {"Client"})]
        public Task CreateAsync(CreateClientInput input)
        {
            return _identityServerClientAppService.CreateAsync(input);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(summary: "删除client", Tags = new[] {"Client"})]
        public Task DeleteAsync(Guid id)
        {
            return _identityServerClientAppService.DeleteAsync(id);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(summary: "更新基本信息", Tags = new[] {"Client"})]
        public Task UpdateBasicDataAsync(Guid id, UpdataBasicDataInput input)
        {
            return _identityServerClientAppService.UpdateBasicDataAsync(id, input);
        }

        [HttpPut("{id}/scopes")]
        [SwaggerOperation(summary: "更新client scopes", Tags = new[] {"Client"})]
        public Task UpdateScopesAsync(Guid id, UpdateScopeInput scopes)
        {
            return _identityServerClientAppService.UpdateScopesAsync(id, scopes);
        }

        [HttpPatch("{id}/redirect-uri/add")]
        [SwaggerOperation(summary: "新增回调地址", Tags = new[] {"Client"})]
        public Task AddRedirectUriAsync([Required] Guid id, [Required] string uri)
        {
            return _identityServerClientAppService.AddRedirectUriAsync(id, uri);
        }

        [HttpPatch("{id}/redirect-uri/remove")]
        [SwaggerOperation(summary: "删除回调地址", Tags = new[] {"Client"})]
        public Task RemoveRedirectUriAsync([Required] Guid id, [Required] string uri)
        {
            return _identityServerClientAppService.RemoveRedirectUriAsync(id, uri);
        }

        [HttpPatch("{id}/logout-redirect-uri/add")]
        [SwaggerOperation(summary: "新增Logout回调地址", Tags = new[] {"Client"})]
        public Task AddLogoutRedirectUriAsync([Required] Guid id, [Required] string uri)
        {
            return _identityServerClientAppService.AddLogoutRedirectUriAsync(id, uri);
        }

        [HttpPatch("{id}/logout-redirect-uri/remove")]
        [SwaggerOperation(summary: "删除Logout回调地址", Tags = new[] {"Client"})]
        public Task RemoveLogoutRedirectUriAsync([Required] Guid id, [Required] string uri)
        {
            return _identityServerClientAppService.RemoveLogoutRedirectUriAsync(id, uri);
        }

        [HttpPatch("{id}/cors/add")]
        [SwaggerOperation(summary: "添加cors", Tags = new[] {"Client"})]
        public Task AddCorsAsync([Required] Guid id, [Required] string origin)
        {
            return _identityServerClientAppService.AddCorsAsync(id, origin);
        }

        [HttpPatch("{id}/cors/remove")]
        [SwaggerOperation(summary: "删除cors", Tags = new[] {"Client"})]
        public Task RemoveCorsAsync([Required] Guid id, [Required] string origin)
        {
            return _identityServerClientAppService.RemoveCorsAsync(id, origin);
        }

        [HttpPatch("{id}/enabled")]
        [SwaggerOperation(summary: "禁用client", Tags = new[] {"Client"})]
        public Task EnabledAsync([Required] Guid id, bool enabled)
        {
            return _identityServerClientAppService.EnabledAsync(id, enabled);
        }
    }
}