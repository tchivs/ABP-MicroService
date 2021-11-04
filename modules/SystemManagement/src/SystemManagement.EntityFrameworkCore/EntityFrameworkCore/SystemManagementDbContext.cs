using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;

namespace SystemManagement.EntityFrameworkCore
{
    [ConnectionStringName(SystemManagementDbProperties.ConnectionStringName)]
    public class SystemManagementDbContext : AbpDbContext<SystemManagementDbContext>, ISystemManagementDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public SystemManagementDbContext(DbContextOptions<SystemManagementDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureSystemManagement();
            
            builder.ConfigureIdentity();
            builder.ConfigureIdentityServer();
            builder.ConfigurePermissionManagement();
            // builder.ConfigureAuditLogging();
            // builder.ConfigureSettingManagement();
            // builder.ConfigureTenantManagement();
            // builder.ConfigureFeatureManagement();
        }
    }
}