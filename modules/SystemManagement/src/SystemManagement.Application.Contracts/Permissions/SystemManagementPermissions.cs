using Volo.Abp.Reflection;

namespace SystemManagement.Permissions
{
    public class SystemManagementPermissions
    {
        public const string GroupName = "SystemManagement";
        public const string AuditLog = GroupName + ".AuditLog";
        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(SystemManagementPermissions));
        }
        public static class IdentityServer
        {
            public const string IdentityServerManagement = "IdentityServerManagement";


            public static class Client
            {
                public const string Default = IdentityServerManagement + ".Client";
                public const string Create = Default + ".Create";
                public const string Update = Default + ".Update";
                public const string Delete = Default + ".Delete";
                public const string Enable = Default + ".Enable";
            }


            public static class ApiResource
            {
                public const string Default = IdentityServerManagement + ".ApiResource";
                public const string Create = Default + ".Create";
                public const string Update = Default + ".Update";
                public const string Delete = Default + ".Delete";
            }
            
            public static class ApiScope
            {
                public const string Default = IdentityServerManagement + ".ApiScope";
                public const string Create = Default + ".Create";
                public const string Update = Default + ".Update";
                public const string Delete = Default + ".Delete";
            }

            public static class IdentityResources
            {
                public const string Default = IdentityServerManagement + ".IdentityResources";
                public const string Create = Default + ".Create";
                public const string Update = Default + ".Update";
                public const string Delete = Default + ".Delete";
            }
          
        }
    }
}