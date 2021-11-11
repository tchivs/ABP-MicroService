using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace BasicManagement.EntityFrameworkCore
{
    [ConnectionStringName(BasicManagementDbProperties.ConnectionStringName)]
    public class BasicManagementDbContext : AbpDbContext<BasicManagementDbContext>, IBasicManagementDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public DbSet<DataDictionaries.DataDictionary> DataDictionaries { get; set; }
        public DbSet<DataDictionaries.DataDictionaryDetail> DataDictionaryDetails { get; set; }
        public BasicManagementDbContext(DbContextOptions<BasicManagementDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureBasicManagement();
        }
    }
}