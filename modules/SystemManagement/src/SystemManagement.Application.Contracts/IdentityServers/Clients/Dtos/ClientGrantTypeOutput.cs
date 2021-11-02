using System;

namespace SystemManagement.IdentityServer.Clients
{
    public class ClientGrantTypeOutput
    {
        public Guid ClientId { get; set; }

        public string GrantType { get; set; }
    }
}