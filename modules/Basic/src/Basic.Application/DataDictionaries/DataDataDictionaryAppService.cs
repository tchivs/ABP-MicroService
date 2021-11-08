using System;
using System.Linq;
using System.Threading.Tasks;
using Nito.Disposables.Internals;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;
using Basic.DataDictionaries.Dtos;
using Micro.Application.Shared;

namespace Basic.DataDictionaries
{
    public class DataDictionaryAppService :
        CrudAppService<DataDictionary, DataDictionaryDto, Guid, PageAndKeyAndIncludeResultRequestDto,
            CreateDataDictionaryDto, UpdateDataDictionaryDto>, IDataDictionaryAppService
    {
        private readonly IDataDictionaryDetailRepository _detailRepository;
        private readonly IDataDictionaryRepository _repository;

        public DataDictionaryAppService(IDataDictionaryRepository repository,
            IDataDictionaryDetailRepository detailRepository) : base(repository)
        {
            _detailRepository = detailRepository;
            _repository = repository;
        }

        protected override async Task<IQueryable<DataDictionary>> CreateFilteredQueryAsync(
            PageAndKeyAndIncludeResultRequestDto input)
        {
            IQueryable<DataDictionary> res = null;
            if (input.Include)
            {
                res = await this.ReadOnlyRepository.WithDetailsAsync(x => x.Details);
            }
            else
            {
                res = await base.CreateFilteredQueryAsync(input);
            }

            if (!string.IsNullOrEmpty(input.Keyword))
            {
                res = res.Where(x => x.Key == input.Keyword);
            }

            return res;
        }

        public override async Task<PagedResultDto<DataDictionaryDto>> GetListAsync(
            PageAndKeyAndIncludeResultRequestDto input)
        {
            await CheckGetListPolicyAsync();

            var query = await CreateFilteredQueryAsync(input);

            var totalCount = await AsyncExecuter.CountAsync(query);

            query = ApplySorting(query, input);
            query = ApplyPaging(query, input);

            var entities = await AsyncExecuter.ToListAsync(query);
            var entityDtos = await MapToGetListOutputDtosAsync(entities);

            return new PagedResultDto<DataDictionaryDto>(
                totalCount,
                entityDtos
            );
        }

        protected override Task<DataDictionary> GetEntityByIdAsync(Guid id)
        {
            return Repository.GetAsync(id);
        }

        public async Task<DataDictionaryDetailDto> CreateDetailAsync(Guid basicId, CreateDataDictionaryDetailDto input)
        {
            await CheckPolicyAsync(CreateDetailPolicyName);
            var entity = ObjectMapper.Map<CreateDataDictionaryDetailDto, DataDictionaryDetail>(input);
            var basic = await this.Repository.GetAsync(basicId);
            if (basic == null)
            {
                throw new BusinessException(BasicErrorCodes.ParentNotFound);
            }

            if (basic.Details.Any(x => x.Name == input.Name))
            {
                throw new BusinessException(BasicErrorCodes.IsExists).WithData(nameof(input.Name), input.Name);
            }
            entity.Basic = basic;
            entity.BasicId = basicId;
            await this._detailRepository.InsertAsync(entity, true);
            //todo:SetTenantId
            return ObjectMapper.Map<DataDictionaryDetail, DataDictionaryDetailDto>(entity);
        }

        public async Task<DataDictionaryDetailDto> UpdateDetailAsync(Guid id, UpdateDataDictionaryDetailDto input)
        {
            await CheckPolicyAsync(UpdateDetailPolicyName);
            var entity = await _detailRepository.GetAsync(id);
            if (entity == null)
            {
                throw new BusinessException(BasicErrorCodes.NotExists).WithData("Name", id);
            }

            //TODO: Check if input has id different than given id and normalize if it's default value, throw ex otherwise
            ObjectMapper.Map<UpdateDataDictionaryDetailDto, DataDictionaryDetail>(input, entity);
            await _detailRepository.UpdateAsync(entity, autoSave: true);
            return ObjectMapper.Map<DataDictionaryDetail, DataDictionaryDetailDto>(entity);
        }

        public async Task DeleteDetailAsync(Guid id)
        {
            await CheckPolicyAsync(DeleteDetailPolicyName);
            var entity = await _detailRepository.GetAsync(id);
            if (entity == null)
            {
                throw new BusinessException(BasicErrorCodes.NotExists).WithData("Name", id);
            }

            await this._detailRepository.DeleteAsync(id, true);
        }

        protected override async Task DeleteByIdAsync(Guid id)
        {
            var data = await Repository.GetAsync(id, true);
            if (data.Details.Count > 0)
            {
                throw new BusinessException(BasicErrorCodes.DetailIsExists).WithData("Footer", ",无法删除");
            }

            await base.DeleteByIdAsync(id);
        }

        public string CreateDetailPolicyName { get; set; } = Permissions.BasicPermissions.DataDictionary.DetailCreate;
        public string UpdateDetailPolicyName { get; set; } = Permissions.BasicPermissions.DataDictionary.DetailUpdate;
        public string DeleteDetailPolicyName { get; set; } = Permissions.BasicPermissions.DataDictionary.DetailCreate;
        protected override string CreatePolicyName { get; set; } = Permissions.BasicPermissions.DataDictionary.Create;
        protected override string UpdatePolicyName { get; set; } = Permissions.BasicPermissions.DataDictionary.Update;
        protected override string DeletePolicyName { get; set; } = Permissions.BasicPermissions.DataDictionary.Delete;
    }
}