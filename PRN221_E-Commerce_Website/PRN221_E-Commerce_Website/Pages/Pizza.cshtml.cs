using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_E_Commerce_Website.Data;
using PRN221_E_Commerce_Website.Data.Entities;
using PRN221_E_Commerce_Website.Data.UnitOfWork;
using System;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;

namespace PRN221_E_Commerce_Website.Pages;

public sealed class PizzaModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    private CancellationToken cancellationToken;
    private AppDbContext _context;
    public Pizza pizza { get; set; }
    public PizzaModel(IUnitOfWork unitOfWork, AppDbContext context)
    {
        _unitOfWork = unitOfWork;
        _context = context;
    }
    public async Task OnGet(int id)
    {
        pizza = await _unitOfWork.PizzaRepository.GetPizzaByIdAsync(id, cancellationToken);
    }

    public async Task<IActionResult> OnPostAsync(
        string Name, string Phone, string Address, int Quantity,
        int PayMethod, float Price, int PizzaId)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        await _context.Database.CreateExecutionStrategy().ExecuteAsync(async () =>
        {
            try
            {
                await _unitOfWork.CreateTransactionAsync(cancellationToken: CancellationToken.None);

                await _unitOfWork.OrderRepository.AddAsync(entity: new()
                {
                    PizzaId = PizzaId,
                    AccountId = 1,
                    OrderDate = DateTime.Now,
                    TotalPrice = Price,
                    Status = "Pending"
                }, cancellationToken: CancellationToken.None);

                await _unitOfWork.OrderDetailRepository.AddAsync(new()
                {
                    PizzaId = PizzaId,
                    Name = Name,
                    Phone = Phone,
                    Address = Address,
                    Quantity = Quantity,
                    PayMethodID = PayMethod,
                    Price = Price,
                    OrderDate = DateTime.Now,
                    IsPaid = false
                }, CancellationToken.None);
            }
            catch { await _unitOfWork.RollBackTransactionAsync(CancellationToken.None); }
            finally { await _unitOfWork.DisposeTransactionAsync(); }
        });


        return RedirectToPage("./Index");
    }
}
