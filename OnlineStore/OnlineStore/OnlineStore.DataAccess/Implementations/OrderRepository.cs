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
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        public void DeleteById(int id)
        {
            throw new NotImplementedException();
            _context.SaveChanges();

        }

        public List<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Order order)
        {
            throw new NotImplementedException();
            _context.SaveChanges();

        }

        public int Update(Order order)
        {
            throw new NotImplementedException();
            _context.SaveChanges();

        }
    }
}
