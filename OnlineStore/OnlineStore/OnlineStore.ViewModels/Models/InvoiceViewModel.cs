using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.ViewModels.Models
{
    public class InvoiceViewModel
    {
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        public int InvoiceStatusId { get; set; }

        public virtual ICollection<InvoiceLineItemViewModel> InvoiceLineItems { get; set; }
        public virtual UserViewModel User { get; set; }
        public virtual OrderViewModel Order { get; set; }
        public virtual InvoiceStatusViewModel InvoiceStatus { get; set; }
    }
}
