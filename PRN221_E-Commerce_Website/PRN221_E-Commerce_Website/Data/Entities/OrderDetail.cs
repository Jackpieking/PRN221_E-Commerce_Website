using System;

namespace PRN221_E_Commerce_Website.Data.Entities;

public sealed class OrderDetail
{
    public int OrderID { get; set; }

    public int RoomId { get; set; }

    public int AccountId { get; set; }

    public DateTime CheckIn { get; set; }

    public DateTime CheckOut { get; set; }

    public int Adult { get; set; }

    public int Child { get; set; }

    public int PayMethodID { get; set; }

    public double TotalPrice { get; set; }

    public bool IsPaid { get; set; }

    public Order Order { get; set; }

    public PayMethod PayMethod { get; set; }
}
