using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace PRN221_E_Commerce_Website.Pages.Auth;

public sealed class LoginModel : PageModel
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
        Response.Redirect(location: "/");
    }
}
