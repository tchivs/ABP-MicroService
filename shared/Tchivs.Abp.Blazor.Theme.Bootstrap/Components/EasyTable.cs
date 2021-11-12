using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Tchivs.Abp.Blazor.Theme.Bootstrap.Components
{
    public class ReadOnlyTable<TAppService, TItem, TKey, TGetListInput> : BootstrapAbpComponentBase, ITable<TKey>
        where TAppService : IReadOnlyAppService<TItem, TItem,TKey, TGetListInput>
        where TItem : class, IEntityDto<TKey>, new()
        where TGetListInput :PagedAndSortedResultRequestDto, new()
    {
        protected virtual IEnumerable<int> PageItemsSource => new int[] {10,  20, 50};
        [Inject][NotNull] protected TAppService? AppService { get; set; }
        protected virtual async Task<QueryData<TItem>> OnQueryAsync(QueryPageOptions option)
        {
            var result = await this.AppService.GetListAsync(Convert2Input(option));
            return new QueryData<TItem>()
            {
                TotalCount = (int) result.TotalCount,
                Items = result.Items
            };
        }

        protected virtual TGetListInput Convert2Input(QueryPageOptions options)
        {
            return new TGetListInput()
            {
                MaxResultCount = options.PageItems,
                SkipCount = options.PageIndex == 1 ? 0 : options.PageIndex * options.PageItems
            };
        }
        public TKey Id { get; set; }
    }
    public class EasyTable<TAppService, TItem, TKey, TGetListInput, TCreateInput,
        TUpdateInput> :ReadOnlyTable<TAppService,TItem,TKey,TGetListInput>
        where TAppService : ICrudAppService<TItem, TKey, TGetListInput, TCreateInput,
            TUpdateInput>, IReadOnlyAppService<TItem,TItem, TKey, TGetListInput>
        where TItem : class, IEntityDto<TKey>, new()
        where TCreateInput : class, new()
        where TUpdateInput : class, new()
        where TGetListInput :PagedAndSortedResultRequestDto, new()
    {
        #region properties

        [Parameter] public string? CreatePolicyName { get; set; }
        [Parameter] public string? UpdatePolicyName { get; set; }
        [Parameter] public string? DeletePolicyName { get; set; }
        protected bool HasCreatePermission { get; set; }
        protected bool HasUpdatePermission { get; set; }
        protected bool HasDeletePermission { get; set; }

        #endregion
        protected  override async Task OnInitializedAsync()
        {
            await SetPermissionsAsync();
            await InvokeAsync(StateHasChanged);
        }
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
        protected virtual async Task<bool> OnSaveAsync(TItem model, ItemChangedType type)
        {
            bool result = false;
            try
            {
                if (type == ItemChangedType.Add)
                {
                    await AppService.CreateAsync(ObjectMapper.Map<TItem, TCreateInput>(model));
                }
                else
                {
                    await AppService.UpdateAsync(model.Id, ObjectMapper.Map<TItem, TUpdateInput>(model));
                }

                result = true;
            }
            catch (Exception e)
            {
                await this.HandleErrorAsync(e);
                result = false;
            }

            return result;
        }

        protected virtual async Task<bool> OnDeleteAsync(IEnumerable<TItem> items)
        {
            bool success = false;
            try
            {
                foreach (var item in items)
                {
                    await this.AppService.DeleteAsync(item.Id);
                }
                success = true;
            }
            catch (Exception e)
            {
                success = false;
                await HandleErrorAsync(e);
            }

            return success;
        }
    }
}