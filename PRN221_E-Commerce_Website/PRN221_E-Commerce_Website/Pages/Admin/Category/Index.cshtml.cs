using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MockProject.Pages.Admin.Category
{
    public class IndexModel : PageModel
    {
        private readonly Models.AppDbContext _context;

        public IndexModel(Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Models.Category> Category { get;set; }

        public async Task OnGetAsync()
        {
            Category = await _context.Categories.ToListAsync();
        }
    }
}
