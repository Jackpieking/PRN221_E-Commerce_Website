using System.Collections.Generic;

namespace PRN221_E_Commerce_Website.Data.Entities;

public sealed class PayMethod
{
    public int Id { get; set; }

    public string Name { get; set; }

    public IEnumerable<OrderDetail> OrderDetails { get; set; }

    public IEnumerable<UserPaymentTransaction> UserPaymentTransactions { get; set; }
}
