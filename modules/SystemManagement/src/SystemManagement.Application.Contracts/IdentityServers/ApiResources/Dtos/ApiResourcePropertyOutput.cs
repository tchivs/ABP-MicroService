using System;

namespace SystemManagement.IdentityServer.Dtos
{
    public class ApiResourcePropertyOutput
    {
        public Guid ApiResourceId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}