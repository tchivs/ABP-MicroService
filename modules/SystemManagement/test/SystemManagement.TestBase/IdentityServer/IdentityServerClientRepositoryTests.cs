using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.IdentityServer.Clients;
using Volo.Abp.Modularity;
using Xunit;

namespace SystemManagement.IdentityServer
{
    /* Write your custom repository tests like that, in this project, as abstract classes.
   * Then inherit these abstract classes from EF Core & MongoDB test projects.
   * In this way, both database providers are tests with the same set tests.
   */
    public abstract class IdentityServerClientRepositoryTests<TStartupModule> : SystemManagementTestBase<TStartupModule>
        where TStartupModule : IAbpModule
    {
         private readonly IClientRepository _repository;

        protected IdentityServerClientRepositoryTests()
        {
            _repository = GetRequiredService<IClientRepository>();
        }

        [Fact]
        public async Task GetListAsyncTest()
        {
          var list =  await _repository.GetListAsync();
          list.ShouldNotBeEmpty();
        }
    }
}