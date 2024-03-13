using System.Collections.Generic;

namespace PRN221_E_Commerce_Website.Data.Entities;

public sealed class Room
{
    public int Id { get; set; }

    public int CategoryId { get; set; }

    public string Name { get; set; }

    public double Price { get; set; }

    public int BedQuantity { get; set; }

    public string RoomImage { get; set; }

    public int IsAvailable { get; set; }

    public IEnumerable<Order> Orders { get; set; }

    public Category Category { get; set; }
}
