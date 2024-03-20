using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN221_E_Commerce_Website.Data;
using PRN221_E_Commerce_Website.Data.Entities;

namespace PRN221_E_Commerce_Website.Pages.Admin.Order;

public class CreateModel : PageModel
{
    private readonly AppDbContext _context;

    public CreateModel(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["AccountId"] = new SelectList(_context.Accounts, "Id", "AccountName");
        ViewData["PizzaId"] = new SelectList(_context.Pizzas, "Id", "Name");
        return Page();
    }

    [BindProperty]
    public Data.Entities.Order Order{ get; set; }


    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Orders.Add(Order);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
