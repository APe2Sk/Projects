using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Entities
{
    public class ProductStatus
    {
        public ProductStatus()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        // in stock
        // out of stock
        public string StatusName { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
