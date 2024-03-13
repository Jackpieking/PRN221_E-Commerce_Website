using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MockProject.Pages.Auth
{
    public class ForgotPasswordModel : PageModel
    {
        public string Account { get; set; }
        public string Email { get; set; }
        public void OnGet()
        {
        }
    }
}
