using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SystemManagement.IdentityServers;
using SystemManagement.Permissions;
using Volo.Abp.Guids;
using Volo.Abp.Identity;

namespace SystemManagement.IdentityServer
{
    [Authorize(Policy = SystemManagementPermissions.IdentityServer.IdentityServerManagement)]
    public class IdentityServerAppService : SystemManagementAppService, IIdentityServerAppService
    {
        private readonly IIdentityClaimTypeRepository _identityClaimTypeRepository;
        private readonly IGuidGenerator _guidGenerator;

        private readonly IdentityClaimTypeManager _identityClaimTypeManager;

        public IdentityServerAppService(IIdentityClaimTypeRepository identityClaimTypeRepository,
            IGuidGenerator guidGenerator,
            IdentityClaimTypeManager identityClaimTypeManager)
        {
            this._identityClaimTypeRepository = identityClaimTypeRepository;
            _guidGenerator = guidGenerator;
            _identityClaimTypeManager = identityClaimTypeManager;
        }

        public async Task<List<IdentityClaimTypeDto>> GetClaimTypes()
        {
            var list = await _identityClaimTypeRepository.GetListAsync();
            return ObjectMapper.Map<List<IdentityClaimType>, List<IdentityClaimTypeDto>>(list);
        }

        public async Task<IdentityClaimType> CreateClaimType(CreateIdentityClaimTypeDto dto)
        {
            var id = _guidGenerator.Create();
            var item = new IdentityClaimType(id, dto.Name, dto.Required, dto.IsStatic, dto.Regex, dto.RegexDescription,
                dto.Description, dto.ValueType);
            return await _identityClaimTypeManager.CreateAsync(item);
        }

        public async Task<IdentityClaimType> UpdateClaimType(Guid id, UpdateIdentityClaimTypeDto dto)
        {
            var item = await _identityClaimTypeRepository.GetAsync(id);
            item.Description = dto.Description;
            item.Required = dto.Required;
            item.RegexDescription = dto.RegexDescription;
            item.Regex = dto.Regex;
            return await _identityClaimTypeManager.UpdateAsync(item);
        }
    }
}