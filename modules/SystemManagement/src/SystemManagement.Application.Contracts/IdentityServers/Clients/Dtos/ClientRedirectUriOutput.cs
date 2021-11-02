using System;
using Volo.Abp.Application.Dtos;
namespace SystemManagement.IdentityServer.Clients
{
    public class ClientRedirectUriOutput
    {
        public virtual Guid ClientId { get; set; }

        public virtual string RedirectUri { get; set; }
    }
}