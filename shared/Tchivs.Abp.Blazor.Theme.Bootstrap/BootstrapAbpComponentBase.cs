using System.Diagnostics.CodeAnalysis;
using BootstrapBlazor.Components;
using Localization.Resources;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Tchivs.Abp.Blazor.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Tchivs.Abp.Blazor.Theme.Bootstrap
{
    public abstract class BootstrapAbpComponentBase : AbpComponentBase

    {
        [Inject]
        [NotNull]
        protected DialogService? DialogService { get; set; }

        [Inject]
        [NotNull]
        public IStringLocalizer<AbpUiResource>? Localizer { get; set; }
        [Inject]
        [NotNull]
        protected ToastService? Toast { get; set; }
        protected BootstrapAbpComponentBase()
        {
            LocalizationResource = typeof(BlazorUIResource);
        }
    }
}