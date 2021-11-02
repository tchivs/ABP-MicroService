using System.ComponentModel.DataAnnotations;

namespace SystemManagement.IdentityServer.Clients
{
    public class RemoveRedirectUriInput
    {
        [Required]
        public string ClientId { get; set; }
        
        [Required]
        public string Uri { get; set; }
    }
}