using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SystemManagement.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Auditing;
using Volo.Abp.AuditLogging;

namespace SystemManagement.AuditLogs
{
    [Authorize(SystemManagementPermissions.AuditLog)]
    public class AuditLogAppService :
        ReadOnlyAppService<AuditLog, GetAuditLogPageListOutput, Guid, PagingAuditLogListInput>, IAuditLogAppService
    {
        private readonly IAuditLogRepository _auditLogRepository;

        public AuditLogAppService(IAuditLogRepository auditLogRepository) : base(auditLogRepository)
        {
            _auditLogRepository = auditLogRepository;
        }

        protected override string GetListPolicyName { get; set; } = SystemManagementPermissions.AuditLog;
    }
}