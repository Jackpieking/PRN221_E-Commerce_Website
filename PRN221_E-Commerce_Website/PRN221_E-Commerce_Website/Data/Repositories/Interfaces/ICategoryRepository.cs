using MockProject.Data.Repositories.Interfaces.Base;
using MockProject.Models;

namespace MockProject.Data.Repositories.Interfaces;

public interface ICategoryRepository : IBaseRepository<Category>
{
    Task<IEnumerable<Category>> GetAllCategoriesVer1Async();
}
