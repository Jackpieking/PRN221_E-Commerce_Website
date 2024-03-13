using PRN221_E_Commerce_Website.Data.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PRN221_E_Commerce_Website.Data.UnitOfWork;

public interface IUnitOfWork
{
    IAccountRepository AccountRepository { get; }

    ICategoryRepository CategoryRepository { get; }

    IOrderDetailRepository OrderDetailRepository { get; }

    IOrderRepository OrderRepository { get; }

    IRoomRepository RoomRepository { get; }

    IPayMethodRepository PayMethodRepository { get; }

    Task CreateTransactionAsync(CancellationToken cancellationToken);

    Task CommitTransactionAsync(CancellationToken cancellationToken);

    Task RollBackTransactionAsync(CancellationToken cancellationToken);

    Task DisposeTransactionAsync();

    Task SaveToDatabaseAsync(CancellationToken cancellationToken);
}
