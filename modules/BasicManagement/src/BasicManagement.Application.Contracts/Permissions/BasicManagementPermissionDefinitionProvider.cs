using BasicManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BasicManagement.Permissions
{
    public class BasicManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(BasicManagementPermissions.GroupName, L("Permission:BasicManagement"));
            var dataDictionaryPermission =
                myGroup.AddPermission(BasicManagementPermissions.DataDictionary.Default,
                    L("Permission:DataDictionary"));
            dataDictionaryPermission.AddChild(BasicManagementPermissions.DataDictionary.Create, L("Permission:Create"));
            dataDictionaryPermission.AddChild(BasicManagementPermissions.DataDictionary.Update, L("Permission:Update"));
            dataDictionaryPermission.AddChild(BasicManagementPermissions.DataDictionary.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
            {
                return LocalizableString.Create<BasicManagementResource>(name);
            }
        }
    }