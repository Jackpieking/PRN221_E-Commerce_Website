using PRN221_E_Commerce_Website.Data.Entities;
using PRN221_E_Commerce_Website.Data.Repositories.Interfaces.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PRN221_E_Commerce_Website.Data.Repositories.Interfaces;

public interface IPizzaRepository : IBaseRepository<Pizza>
{
    Task<IEnumerable<Pizza>> GetAllPizzasVer1Async(CancellationToken cancellationToken);

    Task<Pizza> GetPizzaByIdAsync(
        int Id,
        CancellationToken cancellationToken);

    Task<Pizza> GetPizzasByNameAsync(
        string pizzaName,
        CancellationToken cancellationToken);
}
