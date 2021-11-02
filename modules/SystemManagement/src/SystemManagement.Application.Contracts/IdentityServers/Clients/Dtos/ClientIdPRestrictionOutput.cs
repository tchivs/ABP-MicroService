using System;
using Volo.Abp.Application.Dtos;

namespace SystemManagement.IdentityServer.Clients
{
    public class ClientIdPRestrictionOutput
    {
        public Guid ClientId { get; set; }

        public string Provider { get; set; }
    }
}