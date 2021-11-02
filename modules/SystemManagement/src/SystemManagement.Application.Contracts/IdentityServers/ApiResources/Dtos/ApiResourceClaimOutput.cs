using System;

namespace SystemManagement.IdentityServer.Dtos
{
    public class ApiResourceClaimOutput
    {
        public  Guid ApiResourceId { get; set; }
        
        public  string Type { get;  set; }
    }
}