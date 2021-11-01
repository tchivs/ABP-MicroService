using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace SystemManagement.EntityFrameworkCore
{
    public class SystemManagementHttpApiHostMigrationsDbContext : AbpDbContext<SystemManagementHttpApiHostMigrationsDbContext>
    {
        public SystemManagementHttpApiHostMigrationsDbContext(DbContextOptions<SystemManagementHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureSystemManagement();
        }
    }
}
