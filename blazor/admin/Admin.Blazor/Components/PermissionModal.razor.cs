﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using Volo.Abp.AspNetCore.Components.Web.Configuration;
using Volo.Abp.PermissionManagement;
using Console = System.Console;

namespace Admin.Blazor.Components
{
    public partial class PermissionModal
    {
        [Inject] private IPermissionAppService PermissionAppService { get; set; }

        [Inject]
        private ICurrentApplicationConfigurationCacheResetService CurrentApplicationConfigurationCacheResetService
        {
            get;
            set;
        }

        // protected const string PermissionProviderName = "U/R";
        [Parameter] public string ProviderName { get; set; }
        [Parameter] public string ProviderKey { get; set; }
        [Parameter] public Action? OnClose { get; set; }
        private List<PermissionGrantInfoDto> _disabledPermissions = new List<PermissionGrantInfoDto>();

        public List<TreeItem> Items { get; set; } = new List<TreeItem>();

        TreeItem Convert(PermissionGrantInfoDto permission)
        {
            TreeItem item = new TreeItem()
            {
                Text = permission.DisplayName,
                Key = permission.Name, IsExpanded = true,
                Checked = permission.IsGranted
            };
            groups.Add(item);
            return item;
        }

        private List<TreeItem> groups = new();

        protected override async Task OnParametersSetAsync()
        {
            var result = await PermissionAppService.GetAsync(this.ProviderName, this.ProviderKey);
            foreach (var group in result.Groups)
            {
                TreeItem item = new TreeItem()
                {
                    Text = group.DisplayName,
                    Key = group.Name,
                    IsExpanded = true,
                };

                item.Items = new List<TreeItem>();
                foreach (var permission in group.Permissions)
                {
                    TreeItem children = Convert(permission);
                    if (permission.ParentName == null)
                    {
                        item.Items.Add(children);
                    }
                    else
                    {
                        var p = item.Items.FirstOrDefault(x => x.Key?.ToString() == permission.ParentName);
                        if (p != null)
                        {
                            p.Items ??= new List<TreeItem>();
                            p.Items.Add(children);
                            if (!permission.IsGranted)
                            {
                                children.Checked = false;
                            }
                        }
                        else
                        {
                            item.Items.Add(children);
                        }
                    }
                }

                Items.Add(item);
                item.Checked = item.Items.All(x => x.Checked);
            }
        }

        private async Task Save()
        {
            try
            {
                var updateDto = new UpdatePermissionsDto
                {
                    Permissions = groups
                        .Select(p => new UpdatePermissionDto {IsGranted = p.Checked, Name = p.Key?.ToString()})
                        .ToArray()
                };

                await PermissionAppService.UpdateAsync(this.ProviderName, this.ProviderKey, updateDto);
                await CurrentApplicationConfigurationCacheResetService.ResetAsync();
                OnClose?.Invoke();
                await this.Toast.Success("保存成功");
            }
            catch (Exception e)
            {
                await this.HandleErrorAsync(e);
            }
        }
    }
}