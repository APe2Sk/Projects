using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Entities
{
    public class Order
    {
        public Order()
        {
            OrderLineItems = new HashSet<OrderLineItem>();
        }

        public int Id { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public int TotalOrderAmount { get; set; }
        public int UserId { get; set; }
        public int OrderStatusId { get; set; }
        public int InvoiceId { get; set; }


        public virtual Invoice Invoice { get; set; }
        public virtual User User { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
        public virtual ICollection<OrderLineItem> OrderLineItems { get; set; }
    }
}