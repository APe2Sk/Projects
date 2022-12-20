using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Entities
{
    public class InvoiceStatus
    {
        public InvoiceStatus()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        // Accepted
        // Rejected 
        // Pending
        public string Name { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
