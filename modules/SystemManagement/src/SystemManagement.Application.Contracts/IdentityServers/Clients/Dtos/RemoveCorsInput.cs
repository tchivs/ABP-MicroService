using System.ComponentModel.DataAnnotations;

namespace SystemManagement.IdentityServer.Clients
{
    public class RemoveCorsInput
    {
        [Required]
        public string ClientId { get; set; }
        
        [Required]
        public string Origin { get; set; }
    }
}