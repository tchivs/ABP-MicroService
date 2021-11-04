using System;
using System.Threading.Tasks;
using Xunit;
using SystemManagement.IdentityServer.Clients;
using Volo.Abp.Application.Dtos;
using Shouldly;
namespace SystemManagement.IdentityServer
{
    public sealed class ClientAppServiceTests:SystemManagementApplicationTestBase
    {
        private readonly IIdentityServerClientAppService _clientAppService;
        public ClientAppServiceTests()
        {
            _clientAppService = GetRequiredService<IIdentityServerClientAppService>();
        }
        
        [Fact]
        public Task GetListAsync()
        {
            throw new NotImplementedException();
        }
        [Fact]
        public Task CreateAsync()
        {
            throw new NotImplementedException();
        }
        [Fact]
        public Task DeleteAsync()
        {
            throw new NotImplementedException();
        }
        [Fact]
        public Task UpdateBasicDataAsync()
        {
            throw new NotImplementedException();
        }
        [Fact]
        public Task UpdateScopesAsync()
        {
            throw new NotImplementedException();
        }
        [Fact]
        public Task AddRedirectUriAsync( )
        {
            throw new NotImplementedException();
        }
        [Fact]
        public Task RemoveRedirectUriAsync( )
        {
            throw new NotImplementedException();
        }
        [Fact]
        public Task AddLogoutRedirectUriAsync( )
        {
            throw new NotImplementedException();
        }
        [Fact]
        public Task RemoveLogoutRedirectUriAsync( )
        {
            throw new NotImplementedException();
        }
        [Fact]
        public Task AddCorsAsync( )
        {
            throw new NotImplementedException();
        }
        [Fact]
        public Task RemoveCorsAsync( )
        {
            throw new NotImplementedException();
        }
        [Fact]
        public Task EnabledAsync( )
        {
            throw new NotImplementedException();
        }
    }
}