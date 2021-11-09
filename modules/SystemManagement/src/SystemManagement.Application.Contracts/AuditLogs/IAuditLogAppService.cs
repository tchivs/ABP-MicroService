using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SystemManagement.AuditLogs
{
    public interface IAuditLogAppService : IReadOnlyAppService<GetAuditLogPageListOutput,GetAuditLogPageListOutput,Guid,PagingAuditLogListInput>
    {
      
    }
}