using Microsoft.EntityFrameworkCore.Storage;
using PRN221_E_Commerce_Website.Data.Repositories.Implementations;
using PRN221_E_Commerce_Website.Data.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PRN221_E_Commerce_Website.Data.UnitOfWork;

public sealed class UnitOfWork : IUnitOfWork
{
    private IDbContextTransaction _dbTransaction;
    private readonly AppDbContext _context;
    private IAccountRepository _accountRepository;
    private ICategoryRepository _categoryRepository;
    private IOrderDetailRepository _orderDetailRepository;
    private IOrderRepository _orderRepository;
    private IPizzaRepository _pizzaRepository;
    private IPayMethodRepository _payMethodRepository;

    public IAccountRepository AccountRepository
    {
        get
        {
            _accountRepository ??= new AccountRepository(context: _context);

            return _accountRepository;
        }
    }

    public ICategoryRepository CategoryRepository
    {
        get
        {
            _categoryRepository ??= new CategoryRepository(context: _context);

            return _categoryRepository;
        }
    }

    public IOrderDetailRepository OrderDetailRepository
    {
        get
        {
            _orderDetailRepository ??= new OrderDetailRepository(context: _context);

            return _orderDetailRepository;
        }
    }

    public IOrderRepository OrderRepository
    {
        get
        {
            _orderRepository ??= new OrderRepository(context: _context);

            return _orderRepository;
        }
    }

    public IPizzaRepository PizzaRepository
    {
        get
        {
            _pizzaRepository ??= new PizzaRepository(context: _context);

            return _pizzaRepository;
        }
    }

    public IPayMethodRepository PayMethodRepository
    {
        get
        {
            _payMethodRepository ??= new PayMethodRepository(context: _context);

            return _payMethodRepository;
        }
    }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateTransactionAsync(CancellationToken cancellationToken)
    {
        _dbTransaction = await _context.Database
            .BeginTransactionAsync(cancellationToken: cancellationToken);
    }

    public async Task CommitTransactionAsync(CancellationToken cancellationToken)
    {
        await _dbTransaction.CommitAsync(cancellationToken: cancellationToken);
    }

    public async Task RollBackTransactionAsync(CancellationToken cancellationToken)
    {
        await _dbTransaction.RollbackAsync(cancellationToken: cancellationToken);
    }

    public async Task DisposeTransactionAsync()
    {
        await _dbTransaction.DisposeAsync();
    }

    public IExecutionStrategy CreateExecutionStrategy()
    {
        return _context.Database.CreateExecutionStrategy();
    }

    public Task SaveToDatabaseAsync(CancellationToken cancellationToken)
    {
        return _context.SaveChangesAsync(cancellationToken: cancellationToken);
    }
}
