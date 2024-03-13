namespace MockProject.Models
{
    public class Order
    {
        #region fields
        public int Id { get; set; }

        public int RoomId { get; set; }

        public int AccountId { get; set; }

        public string Status { get; set; }

        public Room Room { get; set; }
        public Account Account { get; set; }
        public OrderDetail OrderDetail { get; set; }
        #endregion
    }
}
