using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using MockProject.Data;
using MockProject.Data.Repositories.Implementations;
using MockProject.Data.Repositories.Interfaces;
using MockProject.Models;

namespace MockProject.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _dbTransaction;
        private readonly AppDbContext _context;
        private IAccountRepository _accountRepository;
        private ICategoryRepository _categoryRepository;
        private IOrderDetailRepository _orderDetailRepository;
        private IOrderRepository _orderRepository;
        private IRoomRepository _roomRepository;
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

        public IRoomRepository RoomRepository
        {
            get
            {
                _roomRepository ??= new RoomRepository(context: _context);

                return _roomRepository;
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
            _dbTransaction = await _context.Database.BeginTransactionAsync(
                cancellationToken: cancellationToken
            );
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
}
