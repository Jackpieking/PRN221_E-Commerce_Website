namespace MockProject.Models
{
    public class Role
    {
        public int Id { get; set; }

        public string RoleName { get; set; }

        public IEnumerable<Account> accounts { get; set; }
    }
}
