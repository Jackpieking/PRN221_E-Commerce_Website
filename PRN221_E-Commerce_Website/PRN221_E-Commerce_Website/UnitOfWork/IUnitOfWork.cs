using MockProject.Data.Repositories.Interfaces;
using MockProject.Data.Repositories.Interfaces.Base;

namespace MockProject.UnitOfWork
{
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
}
