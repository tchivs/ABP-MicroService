using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemManagement.IdentityServer.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SystemManagement.IdentityServer
{
    public interface IApiResourceAppService : IApplicationService
    {
        Task<PagedResultDto<ApiResourceOutput>> GetListAsync(PagingApiRseourceListInput input);

        /// <summary>
        /// 获取所有api resource
        /// </summary>
        /// <returns></returns>
        Task<List<ApiResourceOutput>> GetApiResources();

        /// <summary>
        /// 新增 ApiResource
        /// </summary>
        /// <returns></returns>
        Task CreateAsync(CreateApiResourceInput input);

        /// <summary>
        /// 删除 ApiResource
        /// </summary>
        /// <returns></returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// 更新 ApiResource
        /// </summary>
        /// <returns></returns>
        Task UpdateAsync(UpdateApiResourceInput input);
    }
}