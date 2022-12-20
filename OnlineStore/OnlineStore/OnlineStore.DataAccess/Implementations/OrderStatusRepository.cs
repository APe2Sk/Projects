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
    public class OrderStatusRepository : BaseRepository, IOrderStatusRepository
    {
        public OrderStatusRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        public List<OrderStatus> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderStatus GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
