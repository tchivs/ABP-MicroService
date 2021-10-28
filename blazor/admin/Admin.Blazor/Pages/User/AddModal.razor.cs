using System.Collections.Generic;
using BootstrapBlazor.Components;
using Volo.Abp.Identity;

namespace Admin.Blazor.Pages.User
{
    public partial class AddModal
    {
        public IdentityUserCreateDto Context { get; set; }

        private IEnumerable<SelectedItem> GetRoles()
        {
            throw new System.NotImplementedException();
        }
    }
}