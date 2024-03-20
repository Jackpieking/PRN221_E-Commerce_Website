using System.Collections.Generic;

namespace PRN221_E_Commerce_Website.Data.Entities;

public sealed class Category
{
    public int ID { get; set; }

    public string CategoryName { get; set; }

    public string Description { get; set; }

    public IEnumerable<Pizza> Pizzas { get; set; }
}
