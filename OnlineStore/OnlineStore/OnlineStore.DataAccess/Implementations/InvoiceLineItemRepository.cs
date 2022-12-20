using OnlineStore.DataAccess.EntityFramework;
using OnlineStore.DataAccess.Interfaces;
using OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Implementations
{
    public class InvoiceLineItemRepository : BaseRepository, IInvoiceLineItemRepository
    {
        public InvoiceLineItemRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        public List<InvoiceLineItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public InvoiceLineItem GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
