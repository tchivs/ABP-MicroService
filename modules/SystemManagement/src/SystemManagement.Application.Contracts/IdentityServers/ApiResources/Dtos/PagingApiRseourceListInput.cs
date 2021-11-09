

using Volo.Abp.Application.Dtos;

namespace SystemManagement.IdentityServer.Dtos
{
        public class PagingApiRseourceListInput : PagedAndSortedResultRequestDto
        {
            public string Filter { get; set; }
        }
}