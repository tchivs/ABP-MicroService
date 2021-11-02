using Volo.Abp.Application.Dtos;

namespace SystemManagement.IdentityServer.IdentityResources.Dtos
{
    public class PagingIdentityResourceListInput : PagedResultRequestDto
    {
        public string Filter { get; set; }
    }
}