using System;
using System.Threading.Tasks;
using Basic.DataDictionaries.Dtos;
using Micro.Application.Shared;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace  Basic.DataDictionaries
{
    [RemoteService]
     [Route("api/basic/[controller]")]
   // [Route("api/basic/dict")]
    public class DataDictionaryController : BasicController, IDataDictionaryAppService
    {
        private readonly IDataDictionaryAppService _service;

        public DataDictionaryController(IDataDictionaryAppService service)
        {
            _service = service;
        }
        /// <summary>
        /// 通过ID获取字典
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public Task<DataDictionaryDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }
        /// <summary>
        /// 获取字典列表
        /// </summary>
        /// <param name="input">参数</param>
        /// <returns></returns>
        [HttpGet]
        public Task<PagedResultDto<DataDictionaryDto>> GetListAsync(PageAndKeyAndIncludeResultRequestDto input)
        {
            return _service.GetListAsync(input);
        }
        /// <summary>
        /// 创建字典
        /// </summary>
        /// <param name="input">要添加的内容</param>
        /// <returns></returns>
        [HttpPost]
        public Task<DataDictionaryDto> CreateAsync(CreateDataDictionaryDto input)
        {
            return _service.CreateAsync(input);
        }
        /// <summary>
        /// 修改字典
        /// </summary>
        /// <param name="id">字典ID</param>
        /// <param name="input">要修改的内容</param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public Task<DataDictionaryDto> UpdateAsync(Guid id, UpdateDataDictionaryDto input)
        {
            return _service.UpdateAsync(id, input);
        }
        /// <summary>
        /// 删除字典
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }
        /// <summary>
        /// 创建字典明细项
        /// </summary>
        /// <param name="dictId">字典类型ID</param>
        /// <param name="entity">数据</param>
        /// <returns></returns>
        [HttpPost(template:"{id}/detail",Name = "创建明细")]
        public Task<DataDictionaryDetailDto> CreateDetailAsync(Guid id, CreateDataDictionaryDetailDto entity)
        {
            return this._service.CreateDetailAsync(id, entity);
        }

        [HttpPut("detail/{id}")]
        public Task<DataDictionaryDetailDto> UpdateDetailAsync(Guid id, UpdateDataDictionaryDetailDto input)
        {
            return this._service.UpdateDetailAsync(id, input);
        }
        
        [HttpDelete("detail")]
        public Task DeleteDetailAsync(Guid id)
        {
            return this._service.DeleteDetailAsync(id);
        }
    }
}