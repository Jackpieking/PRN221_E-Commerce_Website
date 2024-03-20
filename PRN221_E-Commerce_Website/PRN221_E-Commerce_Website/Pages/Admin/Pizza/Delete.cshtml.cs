using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_E_Commerce_Website.Data;
using PRN221_E_Commerce_Website.Data.Entities;
using System.Threading.Tasks;

namespace PRN221_E_Commerce_Website.Pages.Admin.Pizzas;

public sealed class DeleteModel : PageModel
{
    private readonly AppDbContext _context;

    public DeleteModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Data.Entities.Pizza Pizza { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Pizza = await _context.Pizzas
            .Include(r => r.Category)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (Pizza == null)
        {
            return NotFound();
        }
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Pizza = await _context.Pizzas.FindAsync(id);

        if (Pizza != null)
        {
            _context.Pizzas.Remove(Pizza);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
