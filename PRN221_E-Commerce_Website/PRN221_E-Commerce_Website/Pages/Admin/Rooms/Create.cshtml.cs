using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN221_E_Commerce_Website.Data;
using PRN221_E_Commerce_Website.Data.Entities;
using System.Threading.Tasks;

namespace PRN221_E_Commerce_Website.Pages.Admin.Rooms;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["CategoryId"] = new SelectList(_context.Categories, "ID", "ID");
        return Page();
    }

    [BindProperty]
    public Room Room { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Rooms.Add(Room);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
