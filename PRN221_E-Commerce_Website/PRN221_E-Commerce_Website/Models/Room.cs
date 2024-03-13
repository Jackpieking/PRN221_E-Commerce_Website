namespace MockProject.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int BedQuantity { get; set; }
        public string RoomImage { get; set; }
        public int isAvailable { get; set; }
        public IEnumerable<Order> Orders { get; set; }

        public Category Category { get; set; }
    }
}
