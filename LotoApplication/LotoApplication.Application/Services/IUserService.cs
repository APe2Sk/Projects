using LotoApplication.Application.Dto;
using LotoApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Application.Services.Implementation
{
    public interface IUserService
    {
        UserDto GetUser(int id);
        IEnumerable<UserDto> GetAllUsers();
        UserDto CreateUser(CreateUserDto user);
        UserDto DeleteUser(int userId);
        UserDto UpdateUser(CreateUserDto user, int userId);
        UserDto PaswordLogin(UserLoginDto model);
    }
}
