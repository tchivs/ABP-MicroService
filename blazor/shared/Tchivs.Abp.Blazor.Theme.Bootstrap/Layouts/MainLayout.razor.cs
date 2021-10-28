using System;
using BootstrapBlazor.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Volo.Abp.UI.Navigation;

namespace Tchivs.Abp.Blazor.Theme.Bootstrap.Layouts
{
    public partial class MainLayout : IDisposable
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        private bool UseTabSet { get; set; } = true;

        private string Theme { get; set; } = "";

        private bool IsOpen { get; set; }

        private bool IsFixedHeader { get; set; } = true;

        private bool IsFixedFooter { get; set; } = true;

        private bool IsFullSide { get; set; } = true;

        private bool ShowFooter { get; set; } = true;

        private List<MenuItem> Menus { get; set; }

        private Dictionary<string, string> TabItemTextDictionary { get; set; }
        [Inject] public IMenuManager MenuManager { get; set; }

        /// <summary>
        /// OnInitialized 方法
        /// </summary>
        protected override async Task OnInitializedAsync()
        {
            // await base.OnInitializedAsync();
            //
            // // 模拟异步线程切换，正式代码中删除此行代码
            // await Task.Yield();

            // 菜单获取可以通过数据库获取，此处为示例直接拼装的菜单集合
            TabItemTextDictionary = new()
            {
                //[""] = "Index"
            };
            var ms = await MenuManager.GetMainMenuAsync();
            Menus = GetIconSideMenuItems(ms.Items);
        }

        private static List<MenuItem> GetIconSideMenuItems(ApplicationMenuItemList items)
        {
            var menus = new List<MenuItem>();
            foreach (var item in items)
            {
                var menu = new MenuItem()
                {
                    Text = item.DisplayName,
                    Icon = item.Icon,
                    Url = item.Url,
                };
                if (menu.Url == "/")
                {
                    menu.Match = NavLinkMatch.All;
                }

                menus.Add(menu);
                menu.Items = GetIconSideMenuItems(item.Items);
            }
            //{
            //    new MenuItem() { Text = "返回组件库", Icon = "fa fa-fw fa-home", Url = "https://www.blazor.zone/components" },
            //    new MenuItem() { Text = "仪表盘", Icon = "fa fa-fw fa-fa", Url = "/admin" , Match = NavLinkMatch.All},
            //    new MenuItem() { Text = "角色管理", Icon = "fa fa-fw fa-table", Url = "/admin/role" },
            //    new MenuItem() { Text = "用户管理", Icon = "fa fa-fw fa-table", Url = "/admin/user" },
            //    new MenuItem() { Text = "IdentityServer", Icon = "fa fa-fw fa-table", Url = "/admin/identityserver" },
            //};

            return menus;
        }

        protected override void OnInitialized()
        {
            NavigationManager.LocationChanged += OnLocationChanged;
        }


        public void Dispose()
        {
            NavigationManager.LocationChanged -= OnLocationChanged;
        }

        private void OnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            //IsCollapseShown = false;
            //InvokeAsync(StateHasChanged);
        }
    }
}