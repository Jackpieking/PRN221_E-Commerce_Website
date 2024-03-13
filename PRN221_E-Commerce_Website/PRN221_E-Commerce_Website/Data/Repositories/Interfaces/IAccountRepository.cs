using MockProject.Data.Repositories.Interfaces.Base;
using MockProject.Models;

namespace MockProject.Data.Repositories.Interfaces;

public interface IAccountRepository : IBaseRepository<Account>
{
    Task<Account> FindByUsernameAndPasswordVer1Async(string username, string password);
}
