using Microsoft.EntityFrameworkCore;
using PRN221_E_Commerce_Website.Data.Repositories.Interfaces.Base;
using System.Threading;
using System.Threading.Tasks;

namespace PRN221_E_Commerce_Website.Data.Repositories.Implementations.Base;

public class BaseRepository<TEntity> :
    IBaseRepository<TEntity>
        where TEntity : class
{
    protected readonly DbSet<TEntity> _entities;

    public BaseRepository(AppDbContext context)
    {
        _entities = context.Set<TEntity>();
    }

    public async Task AddAsync(
        TEntity entity,
        CancellationToken cancellationToken)
    {
        await _entities.AddAsync(
            entity: entity,
            cancellationToken: cancellationToken);
    }

    public Task<bool> DoesDataExistAsync()
    {
        return _entities.AnyAsync();
    }

    public void Remove(TEntity entity)
    {
        _entities.Remove(entity: entity);
    }

    public void Update(TEntity entity)
    {
        _entities.Update(entity: entity);
    }
}
