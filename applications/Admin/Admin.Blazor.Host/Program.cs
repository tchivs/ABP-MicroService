using System.Threading.Tasks;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Admin.Blazor.Host
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            var application = builder.AddApplication<AdminBlazorHostModule>(options =>
            {
                options.UseAutofac();
            });

            var host = builder.Build();
            host.Services.RegisterProvider();

            await application.InitializeAsync(host.Services);

            await host.RunAsync();
        }
    }
}
