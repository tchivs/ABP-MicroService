using System;
using Volo.Abp.Application.Dtos;

namespace SystemManagement.IdentityServer.Clients
{
    public class ClientPropertyOutput
    {
        public Guid ClientId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}