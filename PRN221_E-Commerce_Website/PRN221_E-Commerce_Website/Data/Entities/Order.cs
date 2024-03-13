namespace PRN221_E_Commerce_Website.Data.Entities;

public sealed class Order
{
    public int Id { get; set; }

    public int RoomId { get; set; }

    public int AccountId { get; set; }

    public string Status { get; set; }

    public Room Room { get; set; }
    public Account Account { get; set; }
    public OrderDetail OrderDetail { get; set; }
}
