using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Basic.EntityFrameworkCore
{
    public class BasicHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<BasicHttpApiHostMigrationsDbContext>
    {
        public BasicHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<BasicHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Basic"));

            return new BasicHttpApiHostMigrationsDbContext(builder.Options);
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
