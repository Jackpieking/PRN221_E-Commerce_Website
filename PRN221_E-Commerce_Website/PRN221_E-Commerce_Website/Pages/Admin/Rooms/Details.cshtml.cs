using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_E_Commerce_Website.Data;
using PRN221_E_Commerce_Website.Data.Entities;
using System.Threading.Tasks;

namespace PRN221_E_Commerce_Website.Pages.Admin.Rooms;

public sealed class DetailsModel : PageModel
{
    private readonly AppDbContext _context;

    public DetailsModel(AppDbContext context)
    {
        _context = context;
    }

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
}
