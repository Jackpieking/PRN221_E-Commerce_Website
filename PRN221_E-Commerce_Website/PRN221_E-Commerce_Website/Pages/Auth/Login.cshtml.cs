using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace MockProject.Pages.Auth
{
    public class LoginModel : PageModel
    {
        public string Account { get; set; }
        public string Password { get; set; }
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
        public void OnGet()
        {
        }

        public void OnPost()
        {
            this.Response.Redirect("/");
        }
    }
}
