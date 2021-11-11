using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace BasicManagement.Blazor.Menus
{
    public class BasicManagementMenuContributor : IMenuContributor
    {
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
            context.Menu.AddItem(new ApplicationMenuItem(BasicManagementMenus.Prefix, displayName: "BasicManagement", "/BasicManagement", icon: "fa fa-globe"));
            
            return Task.CompletedTask;
        }
    }
}