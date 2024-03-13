using PRN221_E_Commerce_Website.Data.Entities;
using PRN221_E_Commerce_Website.Data.Repositories.Interfaces.Base;
using System.Threading;
using System.Threading.Tasks;

namespace PRN221_E_Commerce_Website.Data.Repositories.Interfaces;

public interface IAccountRepository : IBaseRepository<Account>
{
    Task<Account> FindByUsernameAndPasswordVer1Async(
        string username,
        string password,
        CancellationToken cancellationToken);
}
