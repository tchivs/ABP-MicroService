using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BasicService.EntityFrameworkCore
{
    public class BasicServiceMigrationDbContextFactory : IDesignTimeDbContextFactory<BasicServiceMigrationDbContext>
    {
        public BasicServiceMigrationDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<BasicServiceMigrationDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Basic"));

            return new BasicServiceMigrationDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
