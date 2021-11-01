﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace SystemManagement.Pages
{
    public class IndexModel : SystemManagementPageModel
    {
        public void OnGet()
        {
            
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}