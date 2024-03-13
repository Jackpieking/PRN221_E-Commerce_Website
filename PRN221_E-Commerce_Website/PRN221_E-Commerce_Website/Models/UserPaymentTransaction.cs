namespace MockProject.Models
{
    public class UserPaymentTransaction
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int PayMethodID { get; set; }
        public DateTime TransactionDate { get; set; }
        public bool IsSuccees { get; set; }
        public PayMethod payMethod { get; set; }
        public Account account { get; set; }
    }
}
