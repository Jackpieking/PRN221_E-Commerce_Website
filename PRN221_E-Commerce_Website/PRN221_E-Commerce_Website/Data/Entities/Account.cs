using System;
using System.Collections.Generic;

namespace PRN221_E_Commerce_Website.Data.Entities;

public sealed class Account
{
    public int Id { get; set; }

    public string AccountName { get; set; }

    public string Password { get; set; }

    public int RoleID { get; set; }

    public string Name { get; set; }

    public string Phone { get; set; }

    public string Gender { get; set; }

    public Role Role { get; set; }

    public IEnumerable<Order> Orders { get; set; }

    public IEnumerable<UserPaymentTransaction> UserPaymentTransaction { get; set; }
}
