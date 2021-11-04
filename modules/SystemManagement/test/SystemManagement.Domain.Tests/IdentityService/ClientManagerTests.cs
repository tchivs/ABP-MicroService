using System.Threading.Tasks;
using Xunit;
using Shouldly;
using SystemManagement.IdentityServer;

namespace SystemManagement.IdentityService
{
    public class ClientManagerTests:SystemManagementDomainTestBase
    {
         private readonly IdenityServerClientManager _clientManager;

        public ClientManagerTests()
        {
             _clientManager = GetRequiredService<IdenityServerClientManager>();
        }

        [Fact]
        public async Task Method1Async()
        {

        }
    }
}