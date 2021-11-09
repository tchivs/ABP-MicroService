using Basic.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Basic.Permissions
{
    public class BasicPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(BasicPermissions.GroupName, L("Permission:Basic"));
            var dataDictionaryPermission = myGroup.AddPermission(BasicPermissions.DataDictionary.Default, L("Permission:DataDictionary"));
            dataDictionaryPermission.AddChild(BasicPermissions.DataDictionary.Create, L("Permission:Create"));
            dataDictionaryPermission.AddChild(BasicPermissions.DataDictionary.Update, L("Permission:Update"));
            dataDictionaryPermission.AddChild(BasicPermissions.DataDictionary.Delete, L("Permission:Delete"));
            //dataDictionaryPermission.AddChild(BasicPermissions.DataDictionary.DetailCreate, L("Permission:DetailCreate"));
            //dataDictionaryPermission.AddChild(BasicPermissions.DataDictionary.DetailUpdate, L("Permission:DetailUpdate"));
            //dataDictionaryPermission.AddChild(BasicPermissions.DataDictionary.DetailDelete, L("Permission:DetailDelete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BasicResource>(name);
        }
    }
}