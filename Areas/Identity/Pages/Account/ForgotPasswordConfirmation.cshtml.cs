using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Time_Sheet_MVC.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordConfirmation : PageModel
    {
        public void OnGet()
        {
        }
    }
}
