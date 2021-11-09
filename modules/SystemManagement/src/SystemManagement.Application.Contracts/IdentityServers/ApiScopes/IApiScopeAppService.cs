using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemManagement.IdentityServer.ApiScopes.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SystemManagement.IdentityServer.ApiScopes
{
    public interface IApiScopeAppService : ICrudAppService<PagingApiScopeListOutput,Guid,PagingApiScopeListInput,CreateApiScopeInput,UpdateCreateApiScopeInput>
    {
       
        Task<List<KeyValuePair<string, string>>> FindAllAsync();
    }
}