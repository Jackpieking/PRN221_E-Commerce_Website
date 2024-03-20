using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PRN221_E_Commerce_Website.Data.Entities;
using PRN221_E_Commerce_Website.Data.UnitOfWork;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PRN221_E_Commerce_Website.Data
{
    public class DataSeeding
    {
        static private AppDbContext _context;
        public DataSeeding(AppDbContext context)
        {
            _context = context;
        }

        public static async Task<bool> SeedingAsync(IUnitOfWork unitOfWork)
        {

            var doesDataExist = await unitOfWork.CategoryRepository.DoesDataExistAsync();

            if (doesDataExist)
            {
                return true;
            }

            doesDataExist = await unitOfWork.PizzaRepository.DoesDataExistAsync();

            if (doesDataExist)
            {
                return true;
            }

            doesDataExist = await unitOfWork.AccountRepository.DoesDataExistAsync();

            if (doesDataExist)
            {
                return true;
            }

            List<Role> roles = new()
            {
                new ()
                {
                    RoleName = "Admin",
                },
                new ()
                {
                    RoleName = "User"
                }
            };

            List<Account> accounts = new() {
                new Account
                {
                    AccountName = "admin",
                    Password = "123",
                    RoleID = 1,
                    Gender = "Male",
                    Name = "Admin",
                    Phone = "0123456789"
                },
                new Account
                {
                    AccountName = "user",
                    Password = "123",
                    RoleID = 2,
                    Gender = "Male",
                    Name = "User",
                    Phone = "0123456789"
                }
            };

            List<Category> categories = new() {
                new Category { CategoryName = "Standard" },
                new Category { CategoryName = "Standard" }
            };

            List<Pizza> pizza = new() {
                new Pizza { Name = "Meat Pizza", Price = 120000, CategoryId = 1, PizzaImage = "meat.png" },
                new Pizza { Name = "Veggie Pizza", Price = 100000, CategoryId = 1, PizzaImage = "veggie.png" },
                new Pizza { Name = "Hawaiian Pizza", Price = 150000, CategoryId = 1, PizzaImage = "hawaiian.png" },
                new Pizza { Name = "Meat Pizza", Price = 180000, CategoryId = 2, PizzaImage = "peperoni.png" },
                new Pizza { Name = "Veggie Pizza", Price = 160000, CategoryId = 2, PizzaImage = "peperoni.png" },
                new Pizza { Name = "Hawaiian Pizza", Price = 210000, CategoryId = 2, PizzaImage = "peperoni.png" }
            };

            var executedTransactionResult = false;

            await _context.Database.CreateExecutionStrategy().ExecuteAsync(async () =>
            {
                try
                {
                    await unitOfWork.CreateTransactionAsync(cancellationToken: CancellationToken.None);

                    foreach (var role in roles)
                    {
                        await _context.AddAsync(role);
                        await _context.SaveChangesAsync();
                    }

                    foreach (var account in accounts)
                    {
                        await unitOfWork.AccountRepository.AddAsync(
                            entity: account,
                            cancellationToken: CancellationToken.None);
                    }

                    foreach (var category in categories)
                    {
                        await unitOfWork.CategoryRepository.AddAsync(
                            entity: category,
                            cancellationToken: CancellationToken.None);
                    }

                    foreach (var product in pizza)
                    {
                        await unitOfWork.PizzaRepository.AddAsync(
                            entity: product,
                            cancellationToken: CancellationToken.None);
                    }

                    await unitOfWork.SaveToDatabaseAsync(cancellationToken: CancellationToken.None);
                    await unitOfWork.CommitTransactionAsync(cancellationToken: CancellationToken.None);

                    executedTransactionResult = true;
                }
                catch { await unitOfWork.RollBackTransactionAsync(CancellationToken.None); }
                finally { await unitOfWork.DisposeTransactionAsync(); }
            });


            return executedTransactionResult;
        }

    }
}
