using AutoMapper;
using OnlineStore.Application.Interfaces;
using OnlineStore.DataAccess.Interfaces;
using OnlineStore.Domain.Entities;
using OnlineStore.Domain.Exceptions;
using OnlineStore.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _rolesRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository rolesRepository, IMapper mapper)
        {
            _rolesRepository = rolesRepository;
            _mapper = mapper;
        }

        public RoleViewModel CreateRole(RoleViewModel role)
        {
            _rolesRepository.CreateRole(_mapper.Map<Role>(role));
            return role;
        }

        public int DeleteRole(int roleId)
        {
            var role = _rolesRepository.GetRoleById(roleId);
            if (role == null)
                throw new NotFoundException("Role not found.");

            _rolesRepository.DeleteRole(role);
            return role.RoleId;
        }

        public RoleViewModel UpdateRole(RoleViewModel role, int roleId)
        {
            var roleToUpdate = _rolesRepository.GetRoleById(roleId);
            if (roleToUpdate == null)
                throw new NotFoundException("Role not found.");

            roleToUpdate.Name = role.Name;
            _rolesRepository.UpdateRole(roleToUpdate);

            return role;
        }

        public List<RoleViewModel> GetAllRole()
        {
            var allRoles = _rolesRepository.GetAllRoles();
            if (allRoles == null)
                throw new NotFoundException("There aren't any roles.");
            var mappedRoles = allRoles.Select(x => _mapper.Map<RoleViewModel>(x)).ToList();
            return mappedRoles;
        }

        public RoleViewModel GetRoleById(int roleId)
        {
            var role = _rolesRepository.GetRoleById(roleId);
            if (role == null)
                throw new NotFoundException("Role not found.");
            return _mapper.Map<RoleViewModel>(role);
        }

        public RoleViewModel GetRoleByName(string roleName)
        {
            var role = _rolesRepository.GetRoleByName(roleName);
            if (role == null)
                throw new NotFoundException("Role not found.");
            return _mapper.Map<RoleViewModel>(role);
        }
    }
}
