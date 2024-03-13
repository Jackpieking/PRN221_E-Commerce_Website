using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MockProject.Models;

namespace MockProject.Pages.Admin.Category
{
    public class DetailsModel : PageModel
    {
        private readonly MockProject.Models.AppDbContext _context;

        public DetailsModel(MockProject.Models.AppDbContext context)
        {
            _context = context;
        }

        public Models.Category Category { get; set; }

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
}
