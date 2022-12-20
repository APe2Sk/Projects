using OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Interfaces
{
    public interface IOrderStatusRepository
    {
        List<OrderStatus> GetAll();
        OrderStatus GetById(int id);
    }
}
