using AutoMapper;
using LotoApplication.Application.Dto;
using LotoApplication.Application.Repositories;
using LotoApplication.Domain.Exceptions;
using LotoApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotoApplication.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> repository;
        private readonly IPasswordHasher passwordHasher;
        private readonly IMapper mapper;


        public UserService(IRepository<User> repository, IPasswordHasher passwordHasher, IMapper mapper)
        {
            this.repository = repository;
            this.passwordHasher = passwordHasher;
            this.mapper = mapper;
        }


        public IEnumerable<UserDto> GetAllUsers()
        {
            var result = repository.GetAll().Select(x => mapper.Map<UserDto>(x)).ToList();

            if (result == null)
                throw new NotFoundException("There aren't any users!");

            return result;
        }

        public UserDto GetUser(int id)
        {
            var result = repository.GetById(id);

            if (result == null)
                throw new NotFoundException("User not found!");

            return mapper.Map<UserDto>(result);
        }
        public UserDto CreateUser(CreateUserDto user)
        {
            var password = passwordHasher.HashPassword(user.Password);
            var newUser = new User(user.FirstName, user.LastName, user.Adress, user.UserName, password, user.Email);

            repository.Create(newUser);
            return mapper.Map<UserDto>(newUser);
        }

        public UserDto DeleteUser(int userId)
        {
            var user = repository.GetById(userId);

            if(user == null) 
                throw new NotFoundException("User not found!");

            repository.Delete(mapper.Map<User>(user));
            return mapper.Map<UserDto>(user);
        }

        public UserDto UpdateUser(CreateUserDto user, int userId)
        {
            var userToUpdate = repository.GetById(userId);
            var maptoUserDto = mapper.Map<UserDto>(user);
            var userInput = mapper.Map<User>(user);

            if (userToUpdate == null)
                throw new NotFoundException("User not found!");

            userToUpdate.Adress = userInput.Adress;
            userToUpdate.Email = userInput.Email;
            userToUpdate.UserName = userInput.UserName;
            userToUpdate.FirstName = userInput.FirstName;
            userToUpdate.LastName = userInput.LastName;
            userToUpdate.Password = passwordHasher.HashPassword(userInput.Password);


            repository.Update(userToUpdate);

            return maptoUserDto;
        }

        public UserDto PaswordLogin(UserLoginDto model)
        {
            var user = repository.GetAll().FirstOrDefault(x => x.UserName == model.UsernameOrEmail || x.Email == model.UsernameOrEmail) ??
                throw new Exception("Wrong email or password");

            if (user.Password != passwordHasher.HashPassword(model.Password))
            {
                throw new Exception("Wrong email or password");
            }

            return mapper.Map<UserDto>(user);
        }
    }
}
