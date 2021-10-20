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
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<BasicResource>(name);
        }
    }
}