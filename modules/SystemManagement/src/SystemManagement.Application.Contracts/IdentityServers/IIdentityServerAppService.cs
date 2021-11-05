using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace SystemManagement.IdentityServers
{
    public interface IIdentityServerAppService : IApplicationService
    {
        Task<List<IdentityClaimTypeDto>> GetClaimTypes();
    }

    public class IdentityClaimTypeDto : ExtensibleEntityDto<Guid>
    {
        public virtual string Name { get;  set; }

        public virtual bool Required { get; set; }

        public virtual bool IsStatic { get;  set; }

        public virtual string Regex { get; set; }

        public virtual string RegexDescription { get; set; }

        public virtual string Description { get; set; }

        public virtual IdentityClaimValueType ValueType { get;  set; }
    }

    public class CreateIdentityClaimTypeDto
    {
        public virtual string Name { get;  set; }

        public virtual bool Required { get; set; }

        public virtual bool IsStatic { get;  set; }

        public virtual string Regex { get; set; }

        public virtual string RegexDescription { get; set; }

        public virtual string Description { get; set; }

        public virtual IdentityClaimValueType ValueType { get;  set; }

    }
    public class UpdateIdentityClaimTypeDto
    {
        
        public virtual bool Required { get; set; }

       
        public virtual string Regex { get; set; }

        public virtual string RegexDescription { get; set; }

        public virtual string Description { get; set; }

       
    }
}