using SystemManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace SystemManagement.Permissions
{
    public class SystemManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var systemGroup = context.AddGroup(SystemManagementPermissions.GroupName, L("Permission:SystemManagement"));
            systemGroup.AddPermission(SystemManagementPermissions.AuditLog,
                   L("Permission:AuditLogManagement"));
            
            
            #region IdentityServer
            var identityServerManagementGroup =  systemGroup.AddPermission(SystemManagementPermissions.IdentityServer.IdentityServerManagement,
                L("Permission:IdentityServerManagement"),
                multiTenancySide: MultiTenancySides.Host);
            // multiTenancySide: MultiTenancySides.Host 只有host租户才有权限
            var clientManagment = identityServerManagementGroup.AddChild(SystemManagementPermissions.IdentityServer.Client.Default,
                L("Permission:IdentityServerManagement:Client"),multiTenancySide: MultiTenancySides.Host);
            clientManagment.AddChild(SystemManagementPermissions.IdentityServer.Client.Create,
                L("Permission:Create"),multiTenancySide: MultiTenancySides.Host);
            clientManagment.AddChild(SystemManagementPermissions.IdentityServer.Client.Update,
                L("Permission:Update"),multiTenancySide: MultiTenancySides.Host);
            clientManagment.AddChild(SystemManagementPermissions.IdentityServer.Client.Delete,
                L("Permission:Delete"),multiTenancySide: MultiTenancySides.Host);
            clientManagment.AddChild(SystemManagementPermissions.IdentityServer.Client.Enable,
                L("Permission:Enable"),multiTenancySide: MultiTenancySides.Host);
            
            
            var apiResourceManagment = identityServerManagementGroup.AddChild(
                SystemManagementPermissions.IdentityServer.ApiResource.Default,
                L("Permission:IdentityServerManagement:ApiResource"),multiTenancySide: MultiTenancySides.Host);
            apiResourceManagment.AddChild(SystemManagementPermissions.IdentityServer.ApiResource.Create,
                L("Permission:Create"),multiTenancySide: MultiTenancySides.Host);
            apiResourceManagment.AddChild(SystemManagementPermissions.IdentityServer.ApiResource.Update,
                L("Permission:Update"),multiTenancySide: MultiTenancySides.Host);
            apiResourceManagment.AddChild(SystemManagementPermissions.IdentityServer.ApiResource.Delete,
                L("Permission:Delete"),multiTenancySide: MultiTenancySides.Host);
            
            var apiScopeManagment = identityServerManagementGroup.AddChild(SystemManagementPermissions.IdentityServer.ApiScope.Default,
                L("Permission:IdentityServerManagement:ApiScope"),multiTenancySide: MultiTenancySides.Host);
            apiScopeManagment.AddChild(SystemManagementPermissions.IdentityServer.ApiScope.Create,
                L("Permission:Create"),multiTenancySide: MultiTenancySides.Host);
            apiScopeManagment.AddChild(SystemManagementPermissions.IdentityServer.ApiScope.Update,
                L("Permission:Update"),multiTenancySide: MultiTenancySides.Host);
            apiScopeManagment.AddChild(SystemManagementPermissions.IdentityServer.ApiScope.Delete,
                L("Permission:Delete"),multiTenancySide: MultiTenancySides.Host);
            
            
            var identityResourcesManagment = identityServerManagementGroup.AddChild(
                SystemManagementPermissions.IdentityServer.IdentityResources.Default,
                L("Permission:IdentityServerManagement:IdentityResources"),multiTenancySide: MultiTenancySides.Host);
            identityResourcesManagment.AddChild(SystemManagementPermissions.IdentityServer.IdentityResources.Create,
                L("Permission:Create"),multiTenancySide: MultiTenancySides.Host);
            identityResourcesManagment.AddChild(SystemManagementPermissions.IdentityServer.IdentityResources.Update,
                L("Permission:Update"),multiTenancySide: MultiTenancySides.Host);
            identityResourcesManagment.AddChild(SystemManagementPermissions.IdentityServer.IdentityResources.Delete,
                L("Permission:Delete"),multiTenancySide: MultiTenancySides.Host);

            #endregion
        }
        

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<SystemManagementResource>(name);
        }
    }
}