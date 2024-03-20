using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PRN221_E_Commerce_Website.Data;

namespace PRN221_E_Commerce_Website.Pages.Auth;

public sealed class RegisterModel : PageModel
{
    private readonly AppDbContext _context;

    private readonly ILogger<RegisterModel> _logger;

    public RegisterModel(ILogger<RegisterModel> logger, AppDbContext context)
    {
        _context = context;
        _logger = logger;
    }

    [FromForm]
    public string Name { get; set; }

    [FromForm]
    public string Username { get; set; }

    [FromForm]
    public string Password { get; set; }

    [FromForm]
    public string ConfirmPassword { get; set; }

    [FromForm]
    public string Email { get; set; }

    public IActionResult OnGet()
    {
        var loginUserId = Request.Cookies["LoginUserId"];

        if (!string.IsNullOrEmpty(loginUserId))
        {
            return RedirectToPage("../Index");
        }

        return Page();
    }

    [BindProperty]
    public Data.Entities.Account Account { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        // Start a local transaction
        if (!ModelState.IsValid)
        {
            return Page();
        }
        if (_context.Accounts.Where(x => x.AccountName == Username).FirstOrDefault() == null && ConfirmPassword == Password)
        {
            Account.AccountName = Username;
            Account.Name = Account.AccountName;
            Account.Password = Account.Password;
            Account.RoleID = 1;
            Account.Phone = "0123456789";
            _context.Accounts.Add(Account);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Login");
        }
        return Page();
    }
}
