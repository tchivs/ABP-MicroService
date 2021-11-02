using System;

namespace SystemManagement.IdentityServer.Dtos
{
    public class ApiResourceScopeOutput
    {
        public Guid ApiResourceId { get; set; }

        public string Scope { get; set; }
    }
}