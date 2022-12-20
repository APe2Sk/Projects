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
    internal class InvoiceStatusRepository : BaseRepository, IInvoiceStatusRepository
    {
        public InvoiceStatusRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        public List<InvoiceStatus> GetAll()
        {
            throw new NotImplementedException();
        }

        public InvoiceStatus GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
