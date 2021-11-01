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
    }
}