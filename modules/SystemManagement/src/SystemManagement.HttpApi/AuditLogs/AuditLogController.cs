using System.Threading.Tasks;
using SystemManagement.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Volo.Abp.Application.Dtos;

namespace SystemManagement.AuditLogs
{
    [Route("api/system/auditLogs")]
    public class AuditLogController : SystemManagementController
    {
        private readonly IAuditLogAppService _auditLogAppService;

        public AuditLogController(IAuditLogAppService auditLogAppService)
        {
            _auditLogAppService = auditLogAppService;
        }
        [HttpPost()]
        [SwaggerOperation(summary: "分页获取审计日志信息", Tags = new[] {"AuditLogs"})]
        public Task<PagedResultDto<GetAuditLogPageListOutput>> ListAsync(PagingAuditLogListInput input)
        {
            return _auditLogAppService.GetListAsync(input);
        }
    }
}