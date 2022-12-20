using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Entities
{
    public class ProductCathegory
    {
        public ProductCathegory()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        // cathegories: electronics, books....
        public string CathegoryName { get; set; }

        public virtual ICollection<Product> Products { get; set; }  
    }
}
