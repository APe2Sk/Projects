using OnlineStore.Domain.Entities;
using OnlineStore.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Interfaces
{
    public interface IUserService
    {
        UserViewModel GetById(int id);
        List<UserViewModel> GetAll();
        UserViewModel CreateUser(UserViewModel newUser);
        string UpdateUser(UserViewModel updatedUser, int userId);
        public string DeleteUser(int id);
    }
}
