using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.ViewModels.Models
{
    public class OrderStatusViewModel
    {
        public string Name { get; set; }

        public virtual IEnumerable<OrderViewModel> Orders { get; set; }
    }
}
