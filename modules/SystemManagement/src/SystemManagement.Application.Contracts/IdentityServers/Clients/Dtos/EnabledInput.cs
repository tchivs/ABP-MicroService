using System.ComponentModel.DataAnnotations;

namespace SystemManagement.IdentityServer.Clients
{
    public class EnabledInput
    {
        [Required]
        public string ClientId { get; set; }
        
        public bool Enabled { get; set; }
    }
}