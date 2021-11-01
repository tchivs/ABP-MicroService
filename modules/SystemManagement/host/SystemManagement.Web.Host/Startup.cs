using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SystemManagement
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<SystemManagementWebHostModule>();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}
