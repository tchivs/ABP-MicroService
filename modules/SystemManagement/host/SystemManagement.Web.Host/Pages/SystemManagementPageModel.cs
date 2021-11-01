using SystemManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace SystemManagement.Pages
{
    public abstract class SystemManagementPageModel : AbpPageModel
    {
        protected SystemManagementPageModel()
        {
            LocalizationResourceType = typeof(SystemManagementResource);
        }
    }
}