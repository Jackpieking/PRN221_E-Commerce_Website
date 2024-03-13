using Microsoft.EntityFrameworkCore;
using PRN221_E_Commerce_Website.Data.Entities;
using PRN221_E_Commerce_Website.Data.Repositories.Implementations.Base;
using PRN221_E_Commerce_Website.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PRN221_E_Commerce_Website.Data.Repositories.Implementations;

public sealed class CategoryRepository :
    BaseRepository<Category>,
    ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context) { }

    public async Task<IEnumerable<Category>> GetAllCategoriesVer1Async(CancellationToken cancellationToken)
    {
        return await _entities
            .AsNoTracking()
            .Select(category => new Category
            {
                CategoryName = category.CategoryName
            })
            .ToListAsync(cancellationToken: cancellationToken);
    }
}
