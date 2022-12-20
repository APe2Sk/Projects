using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.ViewModels.Models
{
    public class InvoiceStatusViewModel
    {
        public string Name { get; set; }

        public virtual IEnumerable<InvoiceViewModel> Invoices { get; set; }
    }
}
