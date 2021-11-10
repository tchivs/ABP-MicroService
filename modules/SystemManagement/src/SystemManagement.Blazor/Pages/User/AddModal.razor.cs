using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using Volo.Abp.Identity;

namespace SystemManagement.Blazor.Pages.User
{
    public partial class AddModal: IResultDialog
    {
     //   [Parameter] public Guid Id { get; set; }
        [Parameter] public IdentityUserCreateDto Context { get; set; }
        [Inject] private IIdentityUserAppService AppService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Roles = new List<SelectedItem>();
            var result = await this.AppService.GetAssignableRolesAsync();
            foreach (var item in result.Items)
            {
                Roles.Add(new SelectedItem(item.Name, item.Name));
            }
        }

        protected override async Task OnParametersSetAsync()
        {
          //  var roles = await AppService.GetRolesAsync(this.Id);
           // this.Context.RoleNames = roles.Items.Select(x => x.Name).ToArray();
        }

        public List<SelectedItem> Roles { get; set; }
        public Task OnClose(DialogResult result)
        {
            return  Task.CompletedTask;
        }
    }
}