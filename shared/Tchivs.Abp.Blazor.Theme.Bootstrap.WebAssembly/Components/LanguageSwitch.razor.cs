using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BootstrapBlazor.Components;
using Microsoft.JSInterop;
using Volo.Abp.Localization;

namespace Tchivs.Abp.Blazor.Theme.Bootstrap.WebAssembly.Components
{
    public partial class LanguageSwitch
    {
   
        private IReadOnlyList<LanguageInfo> _otherLanguages;
        private LanguageInfo _currentLanguage;

        protected override async Task OnInitializedAsync()
        {
            var selectedLanguageName = await JsRuntime.InvokeAsync<string>(
                "localStorage.getItem",
                "Abp.SelectedLanguage"
                );

            _otherLanguages = await LanguageProvider.GetLanguagesAsync();

            if (!_otherLanguages.Any())
            {
                return;
            }

            if (!selectedLanguageName.IsNullOrWhiteSpace())
            {
                _currentLanguage = _otherLanguages.FirstOrDefault(l => l.UiCultureName == selectedLanguageName);
            }

            if (_currentLanguage == null)
            {
                _currentLanguage = _otherLanguages.FirstOrDefault(l => l.UiCultureName == CultureInfo.CurrentUICulture.Name);
            }

            if (_currentLanguage == null)
            {
                _currentLanguage = _otherLanguages.FirstOrDefault();
            }

            _otherLanguages = _otherLanguages.Where(l => l != _currentLanguage).ToImmutableList();
        }
        private async Task SetCulture(SelectedItem item)
        {
            //await JsRuntime.InvokeVoidAsync(
            //  "localStorage.setItem",
            //  "Abp.SelectedLanguage", item.Value
            //  );
            //await JsRuntime.InvokeVoidAsync("location.reload");
        }
        private async Task ChangeLanguageAsync(LanguageInfo language)
        {
            await JsRuntime.InvokeVoidAsync(
                "localStorage.setItem",
                "Abp.SelectedLanguage", language.UiCultureName
                );

            await JsRuntime.InvokeVoidAsync("location.reload");
        }
    }
}
