using Microsoft.EntityFrameworkCore;
using MockProject.Data.Repositories.Implementations.Base;
using MockProject.Data.Repositories.Interfaces;
using MockProject.Models;

namespace MockProject.Data.Repositories.Implementations;

public sealed class AccountRepository : BaseRepository<Account>, IAccountRepository
{
    public AccountRepository(AppDbContext context)
        : base(context) { }

    public Task<Account> FindByUsernameAndPasswordVer1Async(
        string accountname,
        string password
    )
    {
        return _entities
            .Where(
                account =>
                    account.AccountName.Equals(accountname) && account.Password.Equals(password)
            )
            .Select(
                account =>
                    new Account
                    {
                        Id = account.Id,
                        RoleID = account.RoleID,
                        Name = account.Name,
                    }
            )
            .FirstOrDefaultAsync();
    }
}
