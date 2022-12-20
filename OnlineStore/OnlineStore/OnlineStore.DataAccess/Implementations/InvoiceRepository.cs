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
    public class InvoiceRepository : BaseRepository, IInvoiceRepository
    {
        public InvoiceRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
            _context.SaveChanges();

        }

        public List<Invoice> GetAll()
        {
            throw new NotImplementedException();
        }

        public Invoice GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Invoice order)
        {
            throw new NotImplementedException();
            _context.SaveChanges();

        }

        public int Update(Invoice order)
        {
            throw new NotImplementedException();
            _context.SaveChanges();

        }
    }
}
