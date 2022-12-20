using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.ViewModels.Models
{
    public class OrderViewModel
    {
        public DateTime DateTimeCreated { get; set; }
        public int TotalOrderAmount { get; set; }
        public int UserId { get; set; }
        public int OrderStatusId { get; set; }
        public int InvoiceId { get; set; }


        public virtual InvoiceViewModel Invoice { get; set; }
        public virtual UserViewModel User { get; set; }
        public virtual OrderStatusViewModel OrderStatus { get; set; }
        public virtual ICollection<OrderLineItemViewModel> OrderLineItems { get; set; }
    }
}
