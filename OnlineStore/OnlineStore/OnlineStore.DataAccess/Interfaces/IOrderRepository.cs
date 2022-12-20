using OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        Order GetById(int id);
        int Insert (Order order);
        int Update (Order order);
        void DeleteById (int id);
    }
}
