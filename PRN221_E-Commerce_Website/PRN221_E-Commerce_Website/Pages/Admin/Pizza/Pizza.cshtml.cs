using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_E_Commerce_Website.Data;
using PRN221_E_Commerce_Website.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRN221_E_Commerce_Website.Pages.Admin.Pizzas;

public sealed class PizzaModel : PageModel
{
    private readonly AppDbContext _context;

    public PizzaModel(AppDbContext context)
    {
        _context = context;
    }

    public List<Data.Entities.Pizza> Pizza { get; set; }

    public async Task OnGetAsync()
    {
            Pizza = await _context.Pizzas
            .Include(r => r.Category)
            .ToListAsync();

    }
}
