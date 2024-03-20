using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_E_Commerce_Website.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PRN221_E_Commerce_Website.Pages.Admin.Category;

public sealed class CategoryModel : PageModel
{
    private readonly AppDbContext _context;

    public CategoryModel(AppDbContext context)
    {
        _context = context;
    }

    public List<Data.Entities.Category> Category { get; set; }

    public async Task OnGetAsync()
    {
        Category = await _context.Categories.ToListAsync();
    }
}
