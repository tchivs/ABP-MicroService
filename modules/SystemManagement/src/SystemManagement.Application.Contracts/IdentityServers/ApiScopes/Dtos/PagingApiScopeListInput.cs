using Volo.Abp.Application.Dtos;

namespace SystemManagement.IdentityServer.ApiScopes.Dtos
{
    public class PagingApiScopeListInput : PagedResultRequestDto
    {
        public string Filter { get; set; }
    }
}