using Volo.Abp.Account;
using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace SystemManagement
{
    [DependsOn(
        typeof(SystemManagementDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAccountApplicationContractsModule),
        typeof(AbpFeatureManagementApplicationContractsModule),
        typeof(AbpIdentityApplicationContractsModule),
        typeof(AbpPermissionManagementApplicationContractsModule),
        typeof(AbpSettingManagementApplicationContractsModule),
        typeof(AbpTenantManagementApplicationContractsModule),
        typeof(AbpObjectExtendingModule),
        typeof(AbpAuthorizationModule)
        )]
    public class SystemManagementApplicationContractsModule : AbpModule
    {

    }

    public static class SystemManagementRemoteServiceConsts
    {
        public const string RemoteServiceName = "System";
    }
}
