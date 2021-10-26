using System.Collections.Generic;
using System.Threading.Tasks;
using BootstrapBlazor.Components;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Tchivs.Abp.Blazor.Theme.Bootstrap.Components
{
    public partial class TableEx<TAppService, TItem, TKey, TGetListInput, TCreateInput,
        TUpdateInput> : BootstrapComponent where TAppService : ICrudAppService<TItem, TKey, TGetListInput, TCreateInput,
            TUpdateInput>
        where TItem : class, IEntityDto<TKey>, new()
        where TCreateInput : class, new()
        where TUpdateInput : class, new()
        where TGetListInput : new()
    {
        #region properties

        [Parameter] public bool AutoGenerateColumns { get; set; }

        #region policy

        [Parameter] public string? CreatePolicyName { get; set; }
        [Parameter] public string? UpdatePolicyName { get; set; }
        [Parameter] public string? DeletePolicyName { get; set; }
        protected bool HasCreatePermission { get; set; }
        protected bool HasUpdatePermission { get; set; }
        protected bool HasDeletePermission { get; set; }

        #endregion

        [Inject] protected TAppService AppService { get; set; }
        [Inject] protected IStringLocalizer<AbpUiResource> UiLocalizer { get; set; }
        protected virtual IEnumerable<int> PageItemsSource => new int[] {4, 10, 20};
        private readonly TGetListInput  _getListInput = new TGetListInput();
        #endregion

        protected override async Task OnInitializedAsync()
        {
            await SetPermissionsAsync();
            await InvokeAsync(StateHasChanged);
        }

        #region methods

        private async Task<QueryData<TItem>> OnQueryAsync(QueryPageOptions arg)
        {
            var result = await this.AppService.GetListAsync(this._getListInput);
            return new QueryData<TItem>()
            {
                TotalCount = result.TotalCount,
                Items = result.Items
            };
        }

        #region policy

        protected virtual async Task SetPermissionsAsync()
        {
            if (CreatePolicyName != null)
            {
                HasCreatePermission = await AuthorizationService.IsGrantedAsync(CreatePolicyName);
            }

            if (UpdatePolicyName != null)
            {
                HasUpdatePermission = await AuthorizationService.IsGrantedAsync(UpdatePolicyName);
            }

            if (DeletePolicyName != null)
            {
                HasDeletePermission = await AuthorizationService.IsGrantedAsync(DeletePolicyName);
            }
        }

        #endregion

        #endregion
    }
}