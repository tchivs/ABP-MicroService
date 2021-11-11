using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using BasicManagement.DataDictionaries.Dtos;

namespace BasicManagement.DataDictionaries
{
    public interface IDataDictionaryAppService : ICrudAppService<DataDictionaryDto, Guid,
        GetDataDictionaryInput, CreateDataDictionaryDto, UpdateDataDictionaryDto>
    {
        /// <summary>
        /// 添加明细
        /// </summary>
        /// <param name="basicId">父编号</param>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<DataDictionaryDetailDto> CreateDetailAsync(Guid basicId, CreateDataDictionaryDetailDto entity);

        /// <summary>
        /// 修改明细项
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<DataDictionaryDetailDto> UpdateDetailAsync(Guid id, UpdateDataDictionaryDetailDto input);

        Task DeleteDetailAsync(Guid id);
    }
}