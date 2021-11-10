using Volo.Abp.Application.Dtos;

namespace SystemManagement.IdentityServer.IdentityResources.Dtos
{
    public class PagingIdentityResourceListInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}