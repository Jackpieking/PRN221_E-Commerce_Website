using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_E_Commerce_Website.Data.UnitOfWork;

namespace PRN221_E_Commerce_Website.Pages.Auth;

public sealed class LoginModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    private CancellationToken cancellationToken;

    public LoginModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [FromForm]
    public string Username { get; set; }

    [FromForm]
    public string Password { get; set; }

    public IActionResult OnGet()
    {
        var loginUserId = Request.Cookies["LoginUserId"];

        if (!string.IsNullOrEmpty(loginUserId))
        {
            return RedirectToPage("../Index");
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var foundUser = await _unitOfWork.AccountRepository.FindByUsernameAndPasswordVer1Async(
            username: Username,
            password: Password,
            cancellationToken: cancellationToken
        );

        if (Equals(objA: foundUser, objB: null))
        {
            return RedirectToPage("/Auth/Login");
        }

        CookieOptions cookieOptions = new() { Expires = DateTime.Now.AddDays(value: 1) };


        AuthenticationProperties authenticationProperties = new() { IssuedUtc = DateTime.Now.AddDays(7) };
        //    Response.Cookies.Append(
        //        key: "LoginUserId",
        //        value: foundUser.Id.ToString(),
        //        options: cookieOptions
        //    );
        //    Response.Cookies.Append(
        //        key: "LoginUserName",
        //        value: foundUser.Name,
        //        options: cookieOptions
        //    );

        //    Response.Cookies.Append(
        //    key: "LoginUserRole",
        //    value: foundUser.RoleID.ToString(),
        //    options: cookieOptions
        //);

        var claim = new List<Claim>()
            {
                new(ClaimTypes.Name,foundUser.Name),
                new(ClaimTypes.Role,foundUser.RoleID.ToString())
            };
        var claimIdentity = new ClaimsIdentity(claims: claim, "LoginUserName");
        var claimPrinciple = new ClaimsPrincipal(claimIdentity);
        await HttpContext.SignInAsync("LoginUserName", claimPrinciple, authenticationProperties);
        HttpContext.User = claimPrinciple;
        var isAuthenticated = User.Identity.IsAuthenticated;
        return RedirectToPage("../Index");
    }
}
