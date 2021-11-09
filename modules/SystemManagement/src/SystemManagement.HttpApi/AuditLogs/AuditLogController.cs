using System;
using System.Threading.Tasks;
using SystemManagement.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Volo.Abp.Application.Dtos;
using Volo.Abp;
using Volo.Abp.Auditing;

namespace SystemManagement.AuditLogs
{

    [Route("api/system/auditLog")]
    public class AuditLogController : SystemManagementController,IAuditLogAppService
    {
        private readonly IAuditLogAppService _auditLogAppService;

        public AuditLogController(IAuditLogAppService auditLogAppService)
        {
            _auditLogAppService = auditLogAppService;
        }
        [DisableAuditing] [HttpGet("{id}")]
        [SwaggerOperation(summary: "获取审计日志信息", Tags = new[] { "AuditLog" })]
        public Task<GetAuditLogPageListOutput> GetAsync(Guid id)
        {
            return _auditLogAppService.GetAsync(id);
        }

        [DisableAuditing] 
        [HttpGet()]
        [SwaggerOperation(summary: "分页获取审计日志信息", Tags = new[] { "AuditLog" })]
        public virtual Task<PagedResultDto<GetAuditLogPageListOutput>> GetListAsync(PagingAuditLogListInput input)
        {
            return _auditLogAppService.GetListAsync(input);
        }

      
    }
}