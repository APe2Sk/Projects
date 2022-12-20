using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Entities
{
    public class User
    {
        public User()
        {
            Invoices = new HashSet<Invoice>();
            Orders = new HashSet<Order>();
        }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PaswordHashed { get; set; }
        public int UserRoleId { get; set; }

        public virtual Role UserRole { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
