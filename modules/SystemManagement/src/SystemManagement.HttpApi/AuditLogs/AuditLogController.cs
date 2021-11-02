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

    [DisableAuditing]
    [Route("api/system/auditLog")]
    public class AuditLogController : SystemManagementController,IAuditLogAppService
    {
        private readonly IAuditLogAppService _auditLogAppService;

        public AuditLogController(IAuditLogAppService auditLogAppService)
        {
            _auditLogAppService = auditLogAppService;
        }
        [HttpGet()]
        [SwaggerOperation(summary: "分页获取审计日志信息", Tags = new[] { "AuditLogs" })]
        public Task<PagedResultDto<GetAuditLogPageListOutput>> GetListAsync(PagingAuditLogListInput input)
        {
            return _auditLogAppService.GetListAsync(input);
        }

      
    }
}