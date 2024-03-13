using System.Collections.Generic;

namespace PRN221_E_Commerce_Website.Data.Entities;

public sealed class Role
{
    public int Id { get; set; }

    public string RoleName { get; set; }

    public IEnumerable<Account> Accounts { get; set; }
}
