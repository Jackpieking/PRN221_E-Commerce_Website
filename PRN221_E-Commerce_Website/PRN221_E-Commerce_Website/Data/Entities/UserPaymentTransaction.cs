using System;

namespace PRN221_E_Commerce_Website.Data.Entities;

public sealed class UserPaymentTransaction
{
    public int Id { get; set; }

    public int AccountId { get; set; }

    public int PayMethodID { get; set; }

    public DateTime TransactionDate { get; set; }

    public bool IsSuccees { get; set; }

    public PayMethod PayMethod { get; set; }

    public Account Account { get; set; }
}
