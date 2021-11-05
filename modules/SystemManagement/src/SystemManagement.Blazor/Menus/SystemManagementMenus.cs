namespace SystemManagement.Blazor.Menus
{
    public class SystemManagementMenus
    {
        public const string Prefix = "SystemManagement";
        public const string AuditLogs = Prefix + ".AuditLogs";

        //Add your menu items here...
        //public const string Home = Prefix + ".MyNewMenuItem";
    public static class IdentityServer
    {
        public const string Default = "IdentityServer";
        public const string Clients = Default + ".Clients";
        public const string ApiResources = Default + ".ApiResources";
        public const string ApiScopes = Default + ".ApiScopes";
        public const string IdentityResources = Default + ".IdentityResources";

    }
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
    }
}