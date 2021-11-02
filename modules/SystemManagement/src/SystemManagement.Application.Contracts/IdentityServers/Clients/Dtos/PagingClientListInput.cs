using Volo.Abp.Application.Dtos;

namespace SystemManagement.IdentityServer.Clients
{
    public class PagingClientListInput:PagedResultRequestDto
    {
        public string Filter { get; set; }
    }
}