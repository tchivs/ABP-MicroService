using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemManagement.IdentityServer.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SystemManagement.IdentityServer
{
    public interface IApiResourceAppService : ICrudAppService<ApiResourceOutput,Guid,PagingApiRseourceListInput,CreateApiResourceInput,UpdateApiResourceInput>
    {
       
        /// <summary>
        /// 获取所有api resource
        /// </summary>
        /// <returns></returns>
        Task<List<ApiResourceOutput>> GetApiResources();

       

        
    }
}