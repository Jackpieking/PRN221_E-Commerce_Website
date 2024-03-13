using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace MockProject.Models
{
    public class OrderDetail
    {
        public int OrderID { get; set; }

        public int RoomId { get; set; }

        public int AccountId { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public int Adult { get; set; }

        public int Child { get; set; }

        public int PayMethodID { get; set; }

        public double TotalPrice { get; set; }

        public bool isPaid { get; set; }

        public Order Order { get; set; }

        public PayMethod PayMethod { get; set; }
    }
}
