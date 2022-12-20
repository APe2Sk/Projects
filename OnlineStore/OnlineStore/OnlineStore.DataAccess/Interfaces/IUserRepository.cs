using OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        User GetByEmail (string email);
        int CreateUser(User user);
        void UpdateUser (User user);
        void DeleteUserById (User user);
    }
}
