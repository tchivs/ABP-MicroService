﻿using System.ComponentModel.DataAnnotations;

namespace SystemManagement.IdentityServer.Clients
{
    public class CreateClientInput
    {
        [Required] public string ClientId { get; set; }

        [Required] public string ClientName { get; set; }

        public string Description { get; set; }
        
        public string AllowedGrantTypes { get; set; }
    }
}