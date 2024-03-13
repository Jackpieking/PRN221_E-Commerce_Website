using Microsoft.EntityFrameworkCore;
using PRN221_E_Commerce_Website.Data.Entities;
using PRN221_E_Commerce_Website.Data.Repositories.Implementations.Base;
using PRN221_E_Commerce_Website.Data.Repositories.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PRN221_E_Commerce_Website.Data.Repositories.Implementations;

public sealed class AccountRepository :
    BaseRepository<Account>,
    IAccountRepository
{
    public AccountRepository(AppDbContext context) : base(context) { }

    public Task<Account> FindByUsernameAndPasswordVer1Async(
        string username,
        string password,
        CancellationToken cancellationToken)
    {
        return _entities
            .AsNoTracking()
            .Where(account =>
                account.AccountName.Equals(username) &&
                account.Password.Equals(password))
            .Select(account => new Account
            {
                Id = account.Id,
                RoleID = account.RoleID,
                Name = account.Name,
            })
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);
    }
}
