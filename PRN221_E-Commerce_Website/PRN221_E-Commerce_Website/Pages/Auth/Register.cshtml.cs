using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRN221_E_Commerce_Website.Pages.Auth;

public sealed class RegisterModel : PageModel
{
    public string Name { get; set; }

    public string Account { get; set; }

    public string Password { get; set; }

    public string ConfirmPassword { get; set; }

    public string Email { get; set; }

    public void OnGet()
    {
    }
}
