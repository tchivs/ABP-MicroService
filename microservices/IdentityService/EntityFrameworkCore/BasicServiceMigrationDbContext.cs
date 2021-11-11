using Microsoft.EntityFrameworkCore;
using BasicManagement.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace IdentityService.EntityFrameworkCore
{
    public class BasicServiceMigrationDbContext : AbpDbContext<BasicServiceMigrationDbContext>
    {
        public BasicServiceMigrationDbContext(
            DbContextOptions<BasicServiceMigrationDbContext> options
        ) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureBasicManagement();
        }
    }
}