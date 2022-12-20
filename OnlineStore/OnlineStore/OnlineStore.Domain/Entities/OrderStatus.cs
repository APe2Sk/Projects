using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Entities
{
    public class OrderStatus
    {
        public OrderStatus()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        // Pending
        // Accepted
        // Rejected
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
