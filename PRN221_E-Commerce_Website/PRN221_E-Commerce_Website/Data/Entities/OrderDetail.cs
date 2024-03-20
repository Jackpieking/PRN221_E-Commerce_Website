using System;

namespace PRN221_E_Commerce_Website.Data.Entities;

public sealed class OrderDetail
{
    public int OrderID { get; set; }

    public int PizzaId { get; set; }

    public int AccountId { get; set; }

    public string Name { get; set; }

    public string Phone { get; set; }

    public string Address { get; set; }

    public int Quantity { get; set; }

    public DateTime OrderDate { get; set; }

    public int PayMethodID { get; set; }

    public double Price { get; set; }

    public bool IsPaid { get; set; }

    public Order Order { get; set; }

    public PayMethod PayMethod { get; set; }
}
