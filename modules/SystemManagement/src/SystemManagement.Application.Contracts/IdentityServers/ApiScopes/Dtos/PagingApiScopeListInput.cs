using Volo.Abp.Application.Dtos;

namespace SystemManagement.IdentityServer.ApiScopes.Dtos
{
    public class PagingApiScopeListInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}