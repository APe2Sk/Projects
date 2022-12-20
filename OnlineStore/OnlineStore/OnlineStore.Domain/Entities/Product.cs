using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Entities
{
    public class Product
    {
        public Product()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DiscountPercetage { get; set; }
        public int ProductCathegoryId { get; set; }
        public int ProductStatusId { get; set; }
        public int Quantity { get; set; }


        public virtual ProductStatus ProductStatus { get; set; }
        public virtual ProductCathegory ProductCathegory { get; set; }

        public virtual ICollection<InvoiceLineItem> InvoiceLineItems { get; set; }
        public virtual ICollection<OrderLineItem> OrderLineItems { get; set; }
    }
}
