using AutoMapper;
using LotoApplication.Application.Dto;
using LotoApplication.Application.Repositories;
using LotoApplication.Domain.Exceptions;
using LotoApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace LotoApplication.Application.Services.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly IRepository<Admin> repository;
        private readonly IPasswordHasher passwordHasher;
        private readonly IMapper mapper;


        public AdminService(IRepository<Admin> repository, IPasswordHasher passwordHasher, IMapper mapper)
        {
            this.repository = repository;
            this.passwordHasher = passwordHasher;
            this.mapper = mapper;
        }


        public IEnumerable<AdminDto> GetAllAdmins()
        {
            IEnumerable<AdminDto> result = repository.GetAll().Select(x => mapper.Map<AdminDto>(x));

            if (result == null)
                throw new NotFoundException("There aren't any Admins!");

            return result;
        }

        public AdminDto GetAdmin(int id)
        {
            var result = repository.GetById(id);

            if (result == null)
                throw new NotFoundException("Admin not found!");

            return mapper.Map<AdminDto>(result);
        }
        public AdminDto CreateAdmin(CreateAdminDto admin)
        {
            var password = passwordHasher.HashPassword(admin.Password);
            var newAdmin = new Admin(admin.FirstName, admin.LastName, admin.Adress, admin.UserName, password, admin.Email);

            repository.Create(newAdmin);
            return mapper.Map<AdminDto>(newAdmin);
        }

        public AdminDto DeleteAdmin(int AdminId)
        {
            var Admin = repository.GetById(AdminId);

            if (Admin == null)
                throw new NotFoundException("Admin not found!");

            repository.Delete(mapper.Map<Admin>(Admin));
            return mapper.Map<AdminDto>(Admin);
        }

        public AdminDto UpdateAdmin(CreateAdminDto Admin, int AdminId)
        {
            var AdminToUpdate = repository.GetById(AdminId);
            var mapingtoAdminDto = mapper.Map<AdminDto>(Admin);
            var AdminInput = mapper.Map<Admin>(Admin);

            if (AdminToUpdate == null)
                throw new NotFoundException("Admin not found!");

            AdminToUpdate.Adress = AdminInput.Adress;
            AdminToUpdate.Email = AdminInput.Email;
            AdminToUpdate.UserName = AdminInput.UserName;
            AdminToUpdate.FirstName = AdminInput.FirstName;
            AdminToUpdate.LastName = AdminInput.LastName;
            AdminToUpdate.Password = passwordHasher.HashPassword(AdminInput.Password);


            repository.Update(AdminToUpdate);

            return mapingtoAdminDto;

        }

        public AdminDto PaswordLogin(AdminLoginDto model)
        {
            var admin = repository.GetAll()
                .FirstOrDefault(x => x.UserName == model.UsernameOrEmail || x.Email == model.UsernameOrEmail);

            //var a = repository.GetById(4);
            if(admin == null)
                throw new Exception("Wrong email or password");

            if (admin.Password != passwordHasher.HashPassword(model.Password))
            {
                throw new Exception("Wrong email or password");
            }

            return mapper.Map<AdminDto>(admin);
        }
    }
}
