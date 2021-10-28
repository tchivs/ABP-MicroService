using System;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Localization.Resources.AbpUi;
using Volo.Abp.Account.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Identity.Localization;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.Localization;
using Volo.Abp.UI.Navigation;

namespace Admin.Blazor
{
    internal class AdminMenuContributor : IMenuContributor
    {
        private readonly IConfiguration _configuration;

        public AdminMenuContributor(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
            else if (context.Menu.Name == StandardMenus.User)
            {
                await this.ConfigureUserMenuAsync(context);
            }
        }

        private async Task ConfigureUserMenuAsync(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<Basic.Localization.BasicResource>();
            var isWasm = OperatingSystem.IsBrowser();
            var ui = context.GetLocalizer<AbpUiResource>();
            var accountResource = context.GetLocalizer<AccountResource>();

            if (isWasm)
            {
                context.Menu.AddItem(new ApplicationMenuItem("Account.Manage", accountResource["MyAccount"],
                    url: "account/manage-profile", icon: "fa fa-cog"));
            }
            else
            {
                var identityServerUrl = _configuration["AuthServer:Authority"] ?? "";
                context.Menu.AddItem(new ApplicationMenuItem("Account.Manage", accountResource["MyAccount"],
                    $"{identityServerUrl.EnsureEndsWith('/')}Account/Manage?returnUrl={_configuration["App:SelfUrl"]}",
                    icon: "fa fa-cog", order: 1000, null, "_blank").RequireAuthenticated());
                context.Menu.AddItem(new ApplicationMenuItem("Account.Logout", l["Logout"], url: "~/Account/Logout",
                    icon: "fa fa-power-off", order: int.MaxValue - 1000).RequireAuthenticated());
            }
        }

        private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<Basic.Localization.BasicResource>();
            //Add main menu items.
            // context.Menu.AddItem(new ApplicationMenuItem(AdminMenus.Prefix,
            //     displayName: l["Admin"],
            //     "/admin", icon: "fa fa-globe"));

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    AdminMenus.Home,
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home",
                    order: 0
                )
            );
            var administrationMenu = context.Menu.GetAdministration();
            var identityResource = context.GetLocalizer<IdentityResource>();
            var identityMenuItem = new ApplicationMenuItem(AdminMenus.IdentityMenuNames.GroupName,
                identityResource["Menu:IdentityManagement"],
                icon: "far fa-id-card");
            administrationMenu.AddItem(identityMenuItem);
            identityMenuItem.AddItem(new ApplicationMenuItem(
                AdminMenus.IdentityMenuNames.Roles,
                identityResource["Roles"],
                url: "/system/role").RequirePermissions(Volo.Abp.Identity.IdentityPermissions.Roles.Default));
            identityMenuItem.AddItem(new ApplicationMenuItem(
                AdminMenus.IdentityMenuNames.Users,
                identityResource["Users"],
                url: "/system/user").RequirePermissions(Volo.Abp.Identity.IdentityPermissions.Users.Default));
            var abpTenantManagementResource = context.GetLocalizer<AbpTenantManagementResource>();
            var tenantManagementMenuItem = new ApplicationMenuItem(
                AdminMenus.TenantManagementMenuNames.GroupName,
                abpTenantManagementResource["Menu:TenantManagement"],
                icon: "fa fa-users"
            );
            administrationMenu.AddItem(tenantManagementMenuItem);
            tenantManagementMenuItem.AddItem(new ApplicationMenuItem(
                AdminMenus.TenantManagementMenuNames.Tenants,
                abpTenantManagementResource["Tenants"],
                url: "/tenants"
            ).RequirePermissions(TenantManagementPermissions.Tenants.Default));
            return Task.CompletedTask;
        }
    }

    public class AdminMenus
    {
        public const string Prefix = "Admin";
        public const string Home = Prefix + ".Home";

        //Add your menu items here...
        public class IdentityMenuNames
        {
            public const string GroupName = "AbpIdentity";

            public const string Roles = GroupName + ".Roles";
            public const string Users = GroupName + ".Users";
        }

        public class TenantManagementMenuNames
        {
            public const string GroupName = "TenantManagement";

            public const string Tenants = GroupName + ".Tenants";
        }
        //Add your menu items here...
        //public const string Home = Prefix + ".MyNewMenuItem";
    }
}