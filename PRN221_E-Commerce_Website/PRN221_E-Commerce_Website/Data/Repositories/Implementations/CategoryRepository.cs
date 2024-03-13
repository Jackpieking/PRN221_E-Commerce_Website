using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MockProject.Data.Repositories.Implementations.Base;
using MockProject.Data.Repositories.Interfaces;
using MockProject.Models;

namespace MockProject.Data.Repositories.Implementations
{
    public sealed class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context)
            : base(context) { }

        public async Task<IEnumerable<Category>> GetAllCategoriesVer1Async()
        {
            return await _entities
                .Select(category => new Category { CategoryName = category.CategoryName })
                .ToListAsync();
        }
    }
}
