using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemManagement.IdentityServer.ApiScopes.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SystemManagement.IdentityServer.ApiScopes
{
    public interface IApiScopeAppService : IApplicationService
    {
        Task<PagedResultDto<PagingApiScopeListOutput>> GetListAsync(PagingApiScopeListInput input);

        Task CreateAsync(CreateApiScopeInput input);

        Task UpdateAsync(Guid id,UpdateCreateApiScopeInput input);

        Task DeleteAsync(Guid id);

        Task<List<KeyValuePair<string, string>>> FindAllAsync();
    }
}