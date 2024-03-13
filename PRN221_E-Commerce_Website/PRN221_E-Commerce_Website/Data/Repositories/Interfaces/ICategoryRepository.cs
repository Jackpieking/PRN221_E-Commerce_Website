using PRN221_E_Commerce_Website.Data.Entities;
using PRN221_E_Commerce_Website.Data.Repositories.Interfaces.Base;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PRN221_E_Commerce_Website.Data.Repositories.Interfaces;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<IEnumerable<Category>> GetAllCategoriesVer1Async(CancellationToken cancellationToken);
}
