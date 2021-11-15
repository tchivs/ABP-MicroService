using System;
using System.Threading.Tasks;
using BasicManagement.DataDictionaries.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace  BasicManagement.DataDictionaries
{
    [RemoteService]
     [Route("api/basic-management/[controller]")]
   // [Route("api/basic/dict")]
    public class DataDictionaryController : BasicManagementController, IDataDictionaryAppService
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
        [HttpGet("{id}")]
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
        public Task<PagedResultDto<DataDictionaryDto>> GetListAsync(GetDataDictionaryInput input)
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
        /// <param name="basicId">字典类型ID</param>
        /// <param name="entity">数据</param>
        /// <returns></returns>
        [HttpPost(template:"{basicId}/detail",Name = "创建明细")]
        public Task<DataDictionaryDetailDto> CreateDetailAsync(Guid basicId, CreateDataDictionaryDetailDto entity)
        {
            return this._service.CreateDetailAsync(basicId, entity);
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