using Microsoft.EntityFrameworkCore;
using PRN221_E_Commerce_Website.Data.Entities;
using PRN221_E_Commerce_Website.Data.Repositories.Implementations.Base;
using PRN221_E_Commerce_Website.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PRN221_E_Commerce_Website.Data.Repositories.Implementations;

public sealed class PizzaRepository :
    BaseRepository<Pizza>,
    IPizzaRepository
{
    public PizzaRepository(AppDbContext context) : base(context: context) { }

    public async Task<IEnumerable<Pizza>> GetAllPizzasVer1Async(CancellationToken cancellationToken)
    {
        return await _entities
            .AsNoTracking()
            .Select(pizza => new Pizza
            {
                Id = pizza.Id,
                Name = pizza.Name,
                Price = pizza.Price,
                PizzaImage = pizza.PizzaImage,
                Category = new()
                {
                    CategoryName = pizza.Category.CategoryName,
                    Description = pizza.Category.Description
                }
            })
            .ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Pizza> GetPizzaByIdAsync(
        int Id,
        CancellationToken cancellationToken)
    {
        return await _entities
            .AsNoTracking()
            .Where(pizza => pizza.Id == Id)
            .Select(pizza => new Pizza
            {
                Name = pizza.Name,
                Price = pizza.Price,
                PizzaImage = pizza.PizzaImage,
                //IsAvailable = pizza.IsAvailable,
                Category = new()
                {
                    CategoryName = pizza.Category.CategoryName
                },
            })
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }

    public Task<Pizza> GetPizzasByNameAsync(
        string pizzaName,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
