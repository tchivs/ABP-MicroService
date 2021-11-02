using System.Threading.Tasks;
using SystemManagement.Localization;
using SystemManagement.Permissions;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Localization;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.Localization;
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
            // context.Menu.AddItem(new ApplicationMenuItem(SystemManagementMenus.Prefix, displayName: "SystemManagement",
            //     "/SystemManagement", icon: "fa fa-globe"));
            
            //身份标识管理
            var identityResource = context.GetLocalizer<IdentityResource>();
            var identityMenuItem = new ApplicationMenuItem(SystemManagementMenus.IdentityMenuNames.GroupName,
                identityResource["Menu:IdentityManagement"],
                icon: "far fa-id-card");
            administrationMenu.AddItem(identityMenuItem);
            identityMenuItem.AddItem(new ApplicationMenuItem(
                SystemManagementMenus.IdentityMenuNames.Roles,
                identityResource["Roles"], icon: "fa fa-lock",
                url: "/system/role").RequirePermissions(Volo.Abp.Identity.IdentityPermissions.Roles.Default));
            identityMenuItem.AddItem(new ApplicationMenuItem(
                SystemManagementMenus.IdentityMenuNames.Users,
                identityResource["Users"], icon: "fa fa-user",
                url: "/system/user").RequirePermissions(Volo.Abp.Identity.IdentityPermissions.Users.Default));
            
            //租户管理
            var abpTenantManagementResource = context.GetLocalizer<AbpTenantManagementResource>();
            var tenantManagementMenuItem = new ApplicationMenuItem(
                SystemManagementMenus.TenantManagementMenuNames.GroupName,
                abpTenantManagementResource["Menu:TenantManagement"],
                icon: "fa fa-users"
            );
            administrationMenu.AddItem(tenantManagementMenuItem);
            tenantManagementMenuItem.AddItem(new ApplicationMenuItem(
                SystemManagementMenus.TenantManagementMenuNames.Tenants,
                abpTenantManagementResource["Tenants"],
                url: "/tenants"
            ).RequirePermissions(TenantManagementPermissions.Tenants.Default));
            
        
            
            var identityServer =
                new ApplicationMenuItem(SystemManagementMenus.IdentityServer.Default, "IdentityServer",icon:"fa fa-users");
            administrationMenu.AddItem(identityServer);
            identityServer.AddItem(new ApplicationMenuItem(SystemManagementMenus.IdentityServer.Clients, 
                l["client"],url:"/identityServer/client"));
            // context.Menu.AddItem(auditLogMenuItem);
            
            //审计日志
            var auditLogMenuItem = new ApplicationMenuItem(
                SystemManagementMenus.AuditLogs,
                l["Permission:AuditLogManagement"],
                "/auditLogs",icon:"fa fa-address-book"
            );
            administrationMenu.AddItem(auditLogMenuItem).RequirePermissions(SystemManagementPermissions.AuditLog);

            return Task.CompletedTask;
        }
    }
}