using System.Threading.Tasks;
using SystemManagement.Localization;
using SystemManagement.Permissions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.UI.Navigation;

namespace SystemManagement.Blazor.Menus
{
    public class SystemManagementMenuContributor : IMenuContributor
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
            var l = context.GetLocalizer<SystemManagementResource>();
            var administrationMenu = context.Menu.GetAdministration();
            //Add main menu items.
            context.Menu.AddItem(new ApplicationMenuItem(SystemManagementMenus.Prefix, displayName: "SystemManagement", "/SystemManagement", icon: "fa fa-globe"));
            var auditLogMenuItem = new ApplicationMenuItem(
                SystemManagementMenus.AuditLogs,
                l["Permission:AuditLogManagement"],
                "/auditLogs"
            //requiredPermissionName:AdminPermissions.SystemManagement.AuditLog
            );
             administrationMenu.AddItem(auditLogMenuItem).RequirePermissions( SystemManagementPermissions.AuditLog);
           // context.Menu.AddItem(auditLogMenuItem);
            return Task.CompletedTask;
        }
    }
}