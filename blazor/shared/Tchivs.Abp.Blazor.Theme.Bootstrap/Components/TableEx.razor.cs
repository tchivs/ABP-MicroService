using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BootstrapBlazor.Components;
using Localization.Resources.AbpUi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.Localization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Console = System.Console;

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

        /// <summary>
        /// 获得/设置 表格 Toolbar 按钮模板
        /// </summary>
        [Parameter]
        public RenderFragment? TableToolbarTemplate { get; set; }

        [Parameter] public bool AutoGenerateColumns { get; set; }

        /// <summary>
        /// 获得/设置 删除按钮异步回调方法
        /// </summary>
        [Parameter]
        public Func<IEnumerable<TItem>, Task<bool>>? OnDeleteAsync { get; set; }

        /// <summary>
        /// 获得/设置 新建按钮回调方法
        /// </summary>
        [Parameter]
        public Func<Task<TCreateInput>>? OnAddAsync { get; set; }

        /// <summary>
        /// 获得/设置 TableHeader 实例
        /// </summary>
        [Parameter]
        public RenderFragment<TItem>? TableColumns { get; set; }

        [Parameter] public RenderFragment<TItem>? RowButtonTemplate { get; set; }
        [Parameter] public RenderFragment<TCreateInput>? AddTemplate { get; set; }
        [Parameter] public RenderFragment<TUpdateInput>? EditTemplate { get; set; }
        [Parameter] public Size AddSize { get; set; } = Size.Medium;
        [Parameter] public Size EditSize { get; set; } = Size.Medium;

        #region policy

        [Parameter] public string? CreatePolicyName { get; set; }
        [Parameter] public string? UpdatePolicyName { get; set; }
        [Parameter] public string? DeletePolicyName { get; set; }
        protected bool HasCreatePermission { get; set; }
        protected bool HasUpdatePermission { get; set; }
        protected bool HasDeletePermission { get; set; }

        #endregion

        [Inject] protected TAppService AppService { get; set; }

        //  [Inject] protected IStringLocalizer<AbpUiResource> UiLocalizer { get; set; }
        protected virtual IEnumerable<int> PageItemsSource => new int[] {4, 10, 20};
        private readonly TGetListInput _getListInput = new TGetListInput();
        private Table<TItem> table;

        #endregion

        protected override async Task OnInitializedAsync()
        {
            await SetPermissionsAsync();
            await InvokeAsync(StateHasChanged);
        }

        #region methods

        /// <summary>
        /// 行尾列编辑按钮点击回调此方法
        /// </summary>
        /// <param name="item"></param>
        EventCallback<MouseEventArgs> ClickEditButtonCallback(TItem item) =>
            EventCallback.Factory.Create<MouseEventArgs>(this, () => EditAsync(item));

        private async Task<QueryData<TItem>> OnQueryAsync(QueryPageOptions arg)
        {
            var result = await this.AppService.GetListAsync(this._getListInput);
            return new QueryData<TItem>()
            {
                TotalCount = result.TotalCount,
                Items = result.Items
            };
        }

        private async Task EditAsync(TItem item)
        {
            TUpdateInput editInput = ObjectMapper.Map<TItem, TUpdateInput>(item);
            var id = item.Id;
            await this.DialogService.ShowEditDialog(new EditDialogOption<TUpdateInput>()
            {
                IsScrolling = table.ScrollingDialogContent,
                ShowLoading = true,
                Title = table.AddModalTitle,
                DialogBodyTemplate = this.EditTemplate,
                Model = editInput,Size = this.EditSize,
                RowType = table.EditDialogRowType,
                ItemsPerRow = table.EditDialogItemsPerRow,
                LabelAlign = table.EditDialogLabelAlign,
                OnCloseAsync = async () => { },
                OnSaveAsync = async context =>
                {
                    await table.ToggleLoading(true);
                    var valid = false;
                    try
                    {
                        await this.AppService.UpdateAsync(id,(TUpdateInput) context.Model);
                        valid = true;
                    }
                    catch (Exception e)
                    {
                        valid = false;
                        await this.HandleErrorAsync(e);
                    }
                    finally
                    {
                        await table.ToggleLoading(false);
                      //  table.SelectedRows?.Clear();
                    }

                    if (valid)
                    {
                        await InvokeAsync(table.QueryAsync);
                    }

                    return valid;
                }
            });
        }

        public async Task AddAsync()
        {
            TCreateInput createInput;
            if (OnAddAsync == null)
            {
                createInput = new TCreateInput();
            }
            else
            {
                createInput = await OnAddAsync();
            }

            await this.DialogService.ShowEditDialog(new EditDialogOption<TCreateInput>()
            {
                IsScrolling = table.ScrollingDialogContent,
                ShowLoading = true,
                Title = table.AddModalTitle,
                DialogBodyTemplate = this.AddTemplate,
                Model = createInput,Size = this.AddSize,
                RowType = table.EditDialogRowType,
                ItemsPerRow = table.EditDialogItemsPerRow,
                LabelAlign = table.EditDialogLabelAlign,
                OnCloseAsync = async () => { },
                OnSaveAsync = async context =>
                {
                    await table.ToggleLoading(true);
                    var valid = false;
                    try
                    {
                        await this.AppService.CreateAsync((TCreateInput) context.Model);
                        valid = true;
                    }
                    catch (Exception e)
                    {
                        valid = false;
                        await this.HandleErrorAsync(e);
                    }
                    finally
                    {
                        await table.ToggleLoading(false);
                        table.SelectedRows?.Clear();
                    }

                    if (valid)
                    {
                        await InvokeAsync(table.QueryAsync);
                    }

                    return valid;
                }
            });
        }

        public async Task EditAsync()
        {
            TUpdateInput editInput;
            if (table.SelectedRows == null || table.SelectedRows.Count == 0)
            {
                var option = new ToastOption
                {
                    Category = ToastCategory.Information,
                    Title = table.EditButtonToastTitle
                };
                option.Content = string.Format(table.EditButtonToastNotSelectContent,
                    Math.Ceiling(option.Delay / 1000.0));
                await Toast.Show(option);
                return;
            }

            var item = table.SelectedRows[0];
            await EditAsync(item);
        }

        protected async Task<bool> ConfirmDelete()
        {
            var ret = false;
            if (table.SelectedRows == null)
            {
                var option = new ToastOption
                {
                    Category = ToastCategory.Information,
                    Title = table.DeleteButtonToastTitle
                };
                option.Content = string.Format(table.DeleteButtonToastContent, Math.Ceiling(option.Delay / 1000.0));
                await Toast.Show(option);
            }
            else
            {
                ret = true;
            }

            return ret;
        }

        protected async Task DeleteAsync()
        {
            var ret = false;
            var rows = table.SelectedRows;
            if (rows == null)
            {
                return;
            }

            await table.ToggleLoading(true);
            if (OnDeleteAsync != null)
            {
                ret = await OnDeleteAsync(rows);
            }
            else
            {
                foreach (var row in rows)
                {
                    await this.AppService.DeleteAsync(row.Id);
                }

                ret = true;
            }

            var option = new ToastOption()
            {
                Title = this.table.DeleteButtonToastTitle
            };
            option.Category = ret ? ToastCategory.Success : ToastCategory.Error;
            option.Content = string.Format(this.table.DeleteButtonToastResultContent,
                ret ? table.SuccessText : table.FailText, Math.Ceiling(option.Delay / 1000.0));

            if (ret)
            {
                await InvokeAsync(table.QueryAsync);
            }

            if (table.ShowErrorToast || ret)
            {
                await Toast.Show(option);
            }

            await table.ToggleLoading(false);
        }

        protected async Task DeleteAsync(TItem item)
        {
            var ret = false;
            await table.ToggleLoading(true);
            if (OnDeleteAsync != null)
            {
                ret = await OnDeleteAsync(new TItem[] {item});
            }
            else
            {
                await this.AppService.DeleteAsync(item.Id);
                ret = true;
            }

            var option = new ToastOption()
            {
                Title = table.DeleteButtonToastTitle
            };
            option.Category = ret ? ToastCategory.Success : ToastCategory.Error;
            option.Content = string.Format(table.DeleteButtonToastResultContent,
                ret ? table.SuccessText : table.FailText, Math.Ceiling(option.Delay / 1000.0));

            if (ret)
            {
                await InvokeAsync(table.QueryAsync);
            }

            if (table.ShowErrorToast || ret)
            {
                await Toast.Show(option);
            }

            await table.ToggleLoading(false);
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