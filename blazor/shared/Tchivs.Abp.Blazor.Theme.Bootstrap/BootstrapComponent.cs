using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using BootstrapBlazor.Components;
using Localization.Resources;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Volo.Abp.AspNetCore.Components;
using Volo.Abp.AspNetCore.Components.Messages;
using Volo.Abp.DependencyInjection;

namespace Tchivs.Abp.Blazor.Theme.Bootstrap
{
    public abstract class BootstrapComponent : AbpComponentBase

    {
        [Inject][NotNull]
        protected DialogService? DialogService { get; set; }

        [Inject] 
        public   IStringLocalizer<AbpUiResource>? Localizer { get; set; }
        [Inject]
        protected ToastService? Toast { get; set; }
        protected BootstrapComponent()
        {
            LocalizationResource = typeof( Tchivs.Abp.Blazor.Localization.BlazorResource);
        }
    }

  
    [Dependency(ReplaceServices = true)]
    public class BootstrapUiMessageService : IUiMessageService, IScopedDependency
    {
        private readonly MessageService _messageService;
        private readonly IStringLocalizer<AbpUiResource> localizer;

        public BootstrapUiMessageService( IStringLocalizer<AbpUiResource> localizer,BootstrapBlazor.Components.MessageService messageService)
        {
            _messageService = messageService;
            this.localizer = localizer;
        }
        public async Task Info(string message, string title = null, Action<UiMessageOptions> options = null)
        {
          await  _messageService.Show(new MessageOption()
            {
            });
        }

        MessageOption GetOption(UiMessageOptions source)
        {
            return new MessageOption()
            {
            
            };
        }
        public Task Success(string message, string title = null, Action<UiMessageOptions> options = null)
        {
            throw new NotImplementedException();
        }

        public Task Warn(string message, string title = null, Action<UiMessageOptions> options = null)
        {
            throw new NotImplementedException();
        }

        public Task Error(string message, string title = null, Action<UiMessageOptions> options = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Confirm(string message, string title = null, Action<UiMessageOptions> options = null)
        {
            throw new NotImplementedException();
        }
    }
}