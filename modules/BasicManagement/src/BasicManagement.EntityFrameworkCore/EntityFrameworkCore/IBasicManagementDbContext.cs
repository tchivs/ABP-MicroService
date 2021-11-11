using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace BasicManagement.EntityFrameworkCore
{
    [ConnectionStringName(BasicManagementDbProperties.ConnectionStringName)]
    public interface IBasicManagementDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<DataDictionaries.DataDictionary> DataDictionaries { get; set; }
        DbSet<DataDictionaries.DataDictionaryDetail> DataDictionaryDetails { get; set; }
    }
}