using System.Collections.Generic;
using System.Threading.Tasks;
using SystemManagement.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AuditLogging;

namespace SystemManagement.AuditLogs
{

    public class AuditLogAppService : SystemManagementAppService, IAuditLogAppService
    {
        private readonly IAuditLogRepository _auditLogRepository;

        public AuditLogAppService(IAuditLogRepository auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }

        /// <summary>
        /// 分页查询审计日志
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
         [Authorize(Policy = SystemManagement.Permissions.SystemManagementPermissions.AuditLog)]
        public async Task<PagedResultDto<GetAuditLogPageListOutput>> GetListAsync(PagingAuditLogListInput input)
        {
            var list = await _auditLogRepository.GetListAsync(
                input.Sorting,
                input.MaxResultCount,
                input.SkipCount,
                input.StartTime?.Date,
                input.EndTime?.Date,
                input.HttpMethod,
                input.Url,
                null,
                input.UserName,
                input.ApplicationName,
                input.CorrelationId,
                input.MaxExecutionDuration,
                input.MinExecutionDuration,
                input.HasException,
                input.HttpStatusCode);
            var totalCount = await _auditLogRepository.GetCountAsync(
                input.StartTime?.Date,
                input.EndTime?.Date,
                input.HttpMethod,
                input.Url,
                null,
                input.UserName,
                input.ApplicationName,
                input.CorrelationId,
                input.MaxExecutionDuration,
                input.MinExecutionDuration,
                input.HasException,
                input.HttpStatusCode);
            return new PagedResultDto<GetAuditLogPageListOutput>(totalCount,
                ObjectMapper.Map<List<AuditLog>, List<GetAuditLogPageListOutput>>(list));
        }
    }
}