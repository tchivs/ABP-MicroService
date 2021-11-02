using System;

namespace SystemManagement.IdentityServer.Clients
{
    public class ClientScopeOutput
    {
        public Guid ClientId { get; set; }

        public string Scope { get; set; }
    }
}