using System.Threading.Tasks;
using BasicManagement.Localization;
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
            var l = context.GetLocalizer<BasicManagementResource>();
            var administrationMenu = context.Menu.GetAdministration();
            //Add main menu items.
           // context.Menu.AddItem(new ApplicationMenuItem(BasicManagementMenus.Prefix, displayName: "BasicManagement", "/BasicManagement", icon: "fa fa-globe"));
            administrationMenu.AddItem(new ApplicationMenuItem(BasicManagementMenus.DataDictionary, l["DataDictionary"], "/dataDictionary", icon:"fa fa-book"));
            return Task.CompletedTask;
        }
    }
}