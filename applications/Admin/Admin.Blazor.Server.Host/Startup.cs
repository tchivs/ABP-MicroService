using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Admin.Blazor.Server.Host
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<AdminBlazorServerHostModule>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.InitializeApplication();
        }
    }
}
