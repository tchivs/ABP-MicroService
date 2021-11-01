using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SystemManagement.EntityFrameworkCore
{
    public class SystemManagementHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<SystemManagementHttpApiHostMigrationsDbContext>
    {
        public SystemManagementHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<SystemManagementHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("SystemManagement"));

            return new SystemManagementHttpApiHostMigrationsDbContext(builder.Options);
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
