using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Basic.Blazor.Menus
{
    public class BasicMenuContributor : IMenuContributor
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
            context.Menu.AddItem(new ApplicationMenuItem(BasicMenus.Prefix, displayName: "Basic", "/Basic", icon: "fa fa-globe"));
            
            return Task.CompletedTask;
        }
    }
}