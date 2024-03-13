using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_E_Commerce_Website.Data;
using System.Threading.Tasks;

namespace PRN221_E_Commerce_Website.Pages.Admin.Category;

public sealed class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Data.Entities.Category Category { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Categories.Add(Category);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
