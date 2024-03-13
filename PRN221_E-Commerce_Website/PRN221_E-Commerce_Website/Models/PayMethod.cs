namespace MockProject.Models
{
    public class PayMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<OrderDetail> OrderDetails { get; set; }
        public IEnumerable<UserPaymentTransaction> UserPaymentTransactions { get; set; }
    }
}
