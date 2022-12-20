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
    internal class OrderLineItemRepository : BaseRepository, IOrderLineItemRepository
    {
        public OrderLineItemRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        public List<OrderLineItem> GetAll()
        {
            throw new NotImplementedException();
        }

        public OrderLineItem GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
