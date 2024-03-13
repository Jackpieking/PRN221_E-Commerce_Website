using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_E_Commerce_Website.Data;
using PRN221_E_Commerce_Website.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRN221_E_Commerce_Website.Pages.Admin.Rooms;

public sealed class IndexModel : PageModel
{
    private readonly AppDbContext _context;

    public IndexModel(AppDbContext context)
    {
        _context = context;
    }

    public List<Room> Room { get; set; }

    public async Task OnGetAsync()
    {
        Room = await _context.Rooms
            .Include(r => r.Category)
            .ToListAsync();
    }
}
