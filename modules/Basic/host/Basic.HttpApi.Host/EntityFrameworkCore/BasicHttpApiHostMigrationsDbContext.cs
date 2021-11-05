using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Basic.EntityFrameworkCore
{
    public class BasicHttpApiHostMigrationsDbContext : AbpDbContext<BasicHttpApiHostMigrationsDbContext>
    {
        public BasicHttpApiHostMigrationsDbContext(DbContextOptions<BasicHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureBasic();
        }
    }
}
