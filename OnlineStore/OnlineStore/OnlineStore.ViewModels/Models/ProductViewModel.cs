using OnlineStore.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.ViewModels.Models
{
    public class ProductViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DiscountPercetage { get; set; }
        public int Quantity { get; set; }
        public string ProductCathegoryName { get; set; }
    }
}
