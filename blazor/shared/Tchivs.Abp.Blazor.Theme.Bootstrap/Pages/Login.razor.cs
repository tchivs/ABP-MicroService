using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tchivs.Abp.Blazor.Theme.Bootstrap.Pages
{
    public partial class Login
    {
        [NotNull]
        public LoginInput? Model { get; set; } = new LoginInput();
        public class LoginInput
        {
            [DisplayName("用户名")][Required]
            public string? Username { get; set; }
            [DisplayName("密码")]
            [Required]
            public string? Password { get; set; }
        }
        private Task OnInvalidSubmit1(EditContext context)
        {
            Console.WriteLine("OnInvalidSubmit 回调委托: 验证未通过");
            return Task.CompletedTask;
        }
        private async Task OnValidSubmit1(EditContext context)
        {
            await Task.Delay(1000);
            Console.WriteLine("OnValidSubmit 回调委托: 验证通过");
        }
    }
}
