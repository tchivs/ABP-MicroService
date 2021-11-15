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
using BasicManagement.DataDictionaries.Dtos;
using BasicManagement.Permissions;
using Microsoft.AspNetCore.Authorization;

namespace BasicManagement.DataDictionaries
{
    public class DataDictionaryAppService :
        CrudAppService<DataDictionary, DataDictionaryDto, Guid, GetDataDictionaryInput,
            CreateDataDictionaryDto, UpdateDataDictionaryDto>, IDataDictionaryAppService
    {
        private readonly IDataDictionaryDetailRepository _detailRepository;
        // private readonly IDataDictionaryRepository _repository;

        public DataDictionaryAppService(IDataDictionaryRepository repository,
            IDataDictionaryDetailRepository detailRepository) : base(repository)
        {
            _detailRepository = detailRepository;
        }

        [Authorize(BasicManagementPermissions.DataDictionary.Create)]
        public override Task<DataDictionaryDto> CreateAsync(CreateDataDictionaryDto input)
        {
            return base.CreateAsync(input);
        }

        [Authorize(BasicManagementPermissions.DataDictionary.Update)]
        public override Task<DataDictionaryDto> UpdateAsync(Guid id, UpdateDataDictionaryDto input)
        {
            return base.UpdateAsync(id, input);
        }

        [Authorize(BasicManagementPermissions.DataDictionary.Delete)]
        public override Task DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }

        protected override async Task<IQueryable<DataDictionary>> CreateFilteredQueryAsync(
            GetDataDictionaryInput input)
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

            if (!string.IsNullOrEmpty(input.AppName))
            {
                res = res.Where(x => x.AppName == input.AppName);
            }

            return res;
        }

        public override async Task<PagedResultDto<DataDictionaryDto>> GetListAsync(
            GetDataDictionaryInput input)
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

        [Authorize(BasicManagementPermissions.DataDictionary.Create)]
        public async Task<DataDictionaryDetailDto> CreateDetailAsync(Guid basicId, CreateDataDictionaryDetailDto input)
        {
            //  await CheckPolicyAsync(CreateDetailPolicyName);
            var entity = ObjectMapper.Map<CreateDataDictionaryDetailDto, DataDictionaryDetail>(input);
            var basic = await this.Repository.GetAsync(basicId);
            if (basic == null)
            {
                throw new BusinessException(BasicManagementErrorCodes.ParentNotFound);
            }

            if (basic.Details.Any(x => x.Name == input.Name))
            {
                throw new BusinessException(BasicManagementErrorCodes.IsExists).WithData(nameof(input.Name),
                    input.Name);
            }
            else if (basic.Details.Any(x => x.Value == input.Value))
            {
                throw new BusinessException(BasicManagementErrorCodes.IsExists).WithData(nameof(input.Value),
                    input.Value);
            }

            entity.ParentId = basicId;
            await this._detailRepository.InsertAsync(entity, true);
            //todo:SetTenantId
            return ObjectMapper.Map<DataDictionaryDetail, DataDictionaryDetailDto>(entity);
        }

        [Authorize(BasicManagementPermissions.DataDictionary.Update)]
        public async Task<DataDictionaryDetailDto> UpdateDetailAsync(Guid id, UpdateDataDictionaryDetailDto input)
        {
            //await CheckPolicyAsync(UpdateDetailPolicyName);
            var entity = await _detailRepository.GetAsync(id);
            if (entity == null)
            {
                throw new BusinessException(BasicManagementErrorCodes.NotExists).WithData("Name", id);
            }

            var basic = await this.Repository.GetAsync(entity.ParentId);
            if (basic.Details.Any(x => x.Value == input.Value && x.Id != id))
            {
                throw new BusinessException(BasicManagementErrorCodes.IsExists).WithData(nameof(input.Value),
                    input.Value);
            }

            //TODO: Check if input has id different than given id and normalize if it's default value, throw ex otherwise
            ObjectMapper.Map<UpdateDataDictionaryDetailDto, DataDictionaryDetail>(input, entity);
            await _detailRepository.UpdateAsync(entity, autoSave: true);
            return ObjectMapper.Map<DataDictionaryDetail, DataDictionaryDetailDto>(entity);
        }

        [Authorize(BasicManagementPermissions.DataDictionary.Delete)]
        public async Task DeleteDetailAsync(Guid id)
        {
            //await CheckPolicyAsync(DeleteDetailPolicyName);
            var entity = await _detailRepository.GetAsync(id);
            if (entity == null)
            {
                throw new BusinessException(BasicManagementErrorCodes.NotExists).WithData("Name", id);
            }

            await this._detailRepository.DeleteAsync(id, true);
        }

        [Authorize(BasicManagementPermissions.DataDictionary.Delete)]
        protected override async Task DeleteByIdAsync(Guid id)
        {
            var data = await Repository.GetAsync(id, true);
            if (data.Details.Count > 0)
            {
                throw new BusinessException(BasicManagementErrorCodes.DetailIsExists).WithData("Footer", ",无法删除");
            }

            await base.DeleteByIdAsync(id);
        }


        protected override string CreatePolicyName { get; set; } =
            Permissions.BasicManagementPermissions.DataDictionary.Create;

        protected override string UpdatePolicyName { get; set; } =
            Permissions.BasicManagementPermissions.DataDictionary.Update;

        protected override string DeletePolicyName { get; set; } =
            Permissions.BasicManagementPermissions.DataDictionary.Delete;
    }
}