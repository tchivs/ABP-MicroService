using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace SystemManagement.EntityFrameworkCore
{
    [ConnectionStringName(SystemManagementDbProperties.ConnectionStringName)]
    public interface ISystemManagementDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}