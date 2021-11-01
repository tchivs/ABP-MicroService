using System.Threading.Tasks;
using Basic.Permissions;
using Microsoft.AspNetCore.Authorization;

namespace Basic.Samples
{
    public class SampleAppService : BasicAppService, ISampleAppService
    {
        public Task<SampleDto> GetAsync()
        {
            return Task.FromResult(
                new SampleDto
                {
                    Value = 42
                }
            );
        }

        [Authorize(BasicPermissions.GroupName)]
        public Task<SampleDto> GetAuthorizedAsync()
        {
            return Task.FromResult(
                new SampleDto
                {
                    Value = 42
                }
            );
        }
    }
}