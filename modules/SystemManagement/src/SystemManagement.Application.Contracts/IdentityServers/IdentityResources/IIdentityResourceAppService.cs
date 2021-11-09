using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using SystemManagement.IdentityServer.IdentityResources.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SystemManagement.IdentityServer.IdentityResources
{
    public interface IIdentityResourceAppService : ICrudAppService<PagingIdentityResourceListOutput,Guid,PagingIdentityResourceListInput,CreateIdentityResourceInput,UpdateIdentityResourceInput>
    {
        Task<List<PagingIdentityResourceListOutput>> GetAllAsync();
    }
}