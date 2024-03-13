using System.Threading;
using System.Threading.Tasks;

namespace PRN221_E_Commerce_Website.Data.Repositories.Interfaces.Base;

public interface IBaseRepository<in TEntity> where TEntity : class
{
    Task AddAsync(
        TEntity entity,
        CancellationToken cancellationToken);

    void Update(TEntity entity);

    void Remove(TEntity entity);

    Task<bool> DoesDataExistAsync();
}
