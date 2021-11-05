using Microsoft.EntityFrameworkCore;
using Basic.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BasicService.Host.EntityFrameworkCore
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

            modelBuilder.ConfigureBasic();
        }
    }
}