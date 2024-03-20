using System;
using System.Security.Policy;

namespace PRN221_E_Commerce_Website.Data.Entities;

public sealed class Order
{
    public int Id { get; set; }

    public int PizzaId { get; set; }

    public int AccountId { get; set; }

    public DateTime OrderDate { get; set; }

    public double TotalPrice { get; set; }

    public string Status { get; set; }

    public Pizza Pizza { get; set; }
    public Account Account { get; set; }
    public OrderDetail OrderDetail { get; set; }

    
}
