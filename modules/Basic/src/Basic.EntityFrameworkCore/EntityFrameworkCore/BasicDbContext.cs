using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Basic.EntityFrameworkCore
{
    [ConnectionStringName(BasicDbProperties.ConnectionStringName)]
    public class BasicDbContext : AbpDbContext<BasicDbContext>, IBasicDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public BasicDbContext(DbContextOptions<BasicDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureBasic();
        }
    }
}