

using Volo.Abp.Application.Dtos;

namespace SystemManagement.IdentityServer.Dtos
{
        public class PagingApiRseourceListInput : PagedResultRequestDto
        {
            public string Filter { get; set; }
        }
}