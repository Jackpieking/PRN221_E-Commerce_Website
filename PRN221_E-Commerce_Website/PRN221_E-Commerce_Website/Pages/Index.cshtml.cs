using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_E_Commerce_Website.Data;
using PRN221_E_Commerce_Website.Data.Entities;
using PRN221_E_Commerce_Website.Data.UnitOfWork;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PRN221_E_Commerce_Website.Pages;

public sealed class IndexModel : PageModel
{
    private readonly AppDbContext _context;
    private readonly IUnitOfWork _unitOfWork;
    private CancellationToken cancellationToken;

    public IEnumerable<Pizza> Pizzas { get; set; }
    public IndexModel(IUnitOfWork unitOfWork, AppDbContext context)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public async Task OnGet()
    {
        Pizzas = await _unitOfWork.PizzaRepository.GetAllPizzasVer1Async(cancellationToken);
    }
}
