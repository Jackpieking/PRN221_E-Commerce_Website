using System;
using System.Collections.Generic;

namespace MockProject.Models;

public sealed class Category
{
    public int ID { get; set; }

    public string CategoryName { get; set; }

    public string Description { get; set; }

    public IEnumerable<Room> Rooms { get; set; }
}
