using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PRN221_E_Commerce_Website.Pages.Auth
{
    public class LogoutModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            CookieOptions cookieOptions = new()
            {
                Expires = DateTime.Now.AddDays(value: -1)
            };

            Response.Cookies.Append(
                key: "LoginUserName",
                value: "",
                options: cookieOptions);

            Response.Cookies.Append(
                key: "LoginUserId",
                value: "",
                options: cookieOptions);
            Response.Cookies.Append(
                key: "LoginUserRole",
                value: "",
                options: cookieOptions);
            await HttpContext.SignOutAsync("LoginUserName");
            return RedirectToPage("../Index");
        }
    }
}
