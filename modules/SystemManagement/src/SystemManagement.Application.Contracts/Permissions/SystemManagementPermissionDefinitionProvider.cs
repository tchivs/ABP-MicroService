using SystemManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace SystemManagement.Permissions
{
    public class SystemManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var systemGroup = context.AddGroup(SystemManagementPermissions.GroupName, L("Permission:SystemManagement"));
            systemGroup.AddPermission(SystemManagementPermissions.AuditLog,
                   L("Permission:AuditLogManagement"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<SystemManagementResource>(name);
        }
    }
}