using AutoMapper;
using OnlineStore.Application.Interfaces;
using OnlineStore.Domain.Entities;
using OnlineStore.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.DataAccess.Interfaces;
using OnlineStore.ViewModels.Enums;
using OnlineStore.Domain.Exceptions;

namespace OnlineStore.Application.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _usersRepository;
        private readonly IRoleRepository _rolesRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IMapper _mapper;

        public UserService(IUserRepository usersRepository, IRoleRepository rolesRepository, IPasswordHasher passwordHasher, IMapper mapper)
        {
            _usersRepository = usersRepository;
            _rolesRepository = rolesRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public UserViewModel CreateUser(UserViewModel newUser)
        {
            var password = _passwordHasher.HashPassword(newUser.Pasword);

            var mappedToUser = _mapper.Map<User>(newUser);
            var userRole = RoleEnum.Customer.ToString(); // automatically set to CUSTOMER
            var userRoleModel = _rolesRepository.GetRoleByName(userRole);
            mappedToUser.UserRole = userRoleModel;
            mappedToUser.UserRoleId = userRoleModel.RoleId;
            mappedToUser.PaswordHashed = password;

            _usersRepository.CreateUser(mappedToUser);

            return _mapper.Map<UserViewModel>(mappedToUser);
        }

        public string UpdateUser(UserViewModel newUser, int userId)
        {
            var password = _passwordHasher.HashPassword(newUser.Pasword);

            var mappedToUser = _mapper.Map<User>(newUser);
            var userRole = RoleEnum.Customer.ToString(); // automatically set to CUSTOMER
            mappedToUser.UserRole = _rolesRepository.GetRoleByName(userRole);
            mappedToUser.PaswordHashed = password;

            // find the user to update
            var userToUpdate = _usersRepository.GetById(userId);
            if (userToUpdate == null)
                throw new NotFoundException("User not found!");

            userToUpdate.Email = mappedToUser.Email;
            userToUpdate.PaswordHashed = mappedToUser.PaswordHashed;
            userToUpdate.FullName = mappedToUser.FullName;
            userToUpdate.UserRole = mappedToUser.UserRole;
            userToUpdate.UserRoleId = mappedToUser.UserRole.RoleId;


            _usersRepository.UpdateUser(userToUpdate);

            return "User has been updated.";
        }

        public List<UserViewModel> GetAll()
        {
            var users = _usersRepository.GetAll();

            var mappedUsers = users.Select(x => _mapper.Map<UserViewModel>(x)).ToList();

            if(!mappedUsers.Any())
                throw new NotFoundException("There aren't any users registered.");

            return mappedUsers;
        }

        public UserViewModel GetById(int id)
        {
            var user = _usersRepository.GetById(id);

            if (user == null)
                throw new NotFoundException("User not found!");
            
            var mappedUser = _mapper.Map<UserViewModel>(user);
            return mappedUser;
        }

        public string DeleteUser(int id)
        {
            var userToDelete = _usersRepository.GetById(id);
            if (userToDelete == null)
                throw new NotFoundException("User not found!");

            _usersRepository.DeleteUserById(userToDelete);

            return "User has been deleted.";
        }
    }
}
