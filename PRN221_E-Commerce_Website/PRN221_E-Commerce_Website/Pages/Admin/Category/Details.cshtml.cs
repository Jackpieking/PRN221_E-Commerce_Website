using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_E_Commerce_Website.Data;
using System.Threading.Tasks;

namespace PRN221_E_Commerce_Website.Pages.Admin.Category;

public sealed class DetailsModel : PageModel
{
    private readonly AppDbContext _context;

    public DetailsModel(AppDbContext context)
    {
        _context = context;
    }

    public Data.Entities.Category Category { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Category = await _context.Categories.FirstOrDefaultAsync(m => m.ID == id);

        if (Category == null)
        {
            return NotFound();
        }
        return Page();
    }
}
