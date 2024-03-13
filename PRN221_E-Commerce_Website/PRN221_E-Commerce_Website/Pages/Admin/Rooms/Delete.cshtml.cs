using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_E_Commerce_Website.Data;
using PRN221_E_Commerce_Website.Data.Entities;
using System.Threading.Tasks;

namespace PRN221_E_Commerce_Website.Pages.Admin.Rooms;

public sealed class DeleteModel : PageModel
{
    private readonly AppDbContext _context;

    public DeleteModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Room Room { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Room = await _context.Rooms
            .Include(r => r.Category)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (Room == null)
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

        Room = await _context.Rooms.FindAsync(id);

        if (Room != null)
        {
            _context.Rooms.Remove(Room);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
