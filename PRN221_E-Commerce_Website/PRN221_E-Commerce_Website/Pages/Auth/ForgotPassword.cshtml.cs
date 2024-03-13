using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRN221_E_Commerce_Website.Pages.Auth;

public sealed class ForgotPasswordModel : PageModel
{
    public string Account { get; set; }

    public string Email { get; set; }

    public void OnGet()
    {
    }
}
