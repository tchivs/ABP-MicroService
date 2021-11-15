namespace BasicManagement.Blazor
{
    public abstract class BasicManagementComponent:Tchivs.Abp.Blazor.Theme.Bootstrap.BootstrapAbpComponentBase{
        protected BasicManagementComponent()
        {
            this.LocalizationResource = typeof(BasicManagement.Localization.BasicManagementResource);
        }
    }
}