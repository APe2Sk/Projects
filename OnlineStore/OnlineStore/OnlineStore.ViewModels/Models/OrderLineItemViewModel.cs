using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.ViewModels.Models
{
    public class OrderLineItemViewModel
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Quantity { get; set; }
        public int DiscountPercentage { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual ProductViewModel Product { get; set; }
        public virtual OrderViewModel Order { get; set; }
    }
}
