using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Admin.Blazor
{
    internal class AdminMenuContributor : IMenuContributor
    {
        private IConfiguration configuration;

        public AdminMenuContributor(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            //Add main menu items.
            context.Menu.AddItem(new ApplicationMenuItem(AdminMenus.Prefix, displayName: "Admin", "/Admin", icon: "fa fa-globe"));

            return Task.CompletedTask;
        }
    }
    public class AdminMenus
    {
        public const string Prefix = "Admin";

        //Add your menu items here...
        //public const string Home = Prefix + ".MyNewMenuItem";

    }
}