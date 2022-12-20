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
    public class RoleRepository : BaseRepository, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext) { }

        public Role CreateRole(Role newRole)
        {
            _context.Role.Add(newRole);
            _context.SaveChanges();
            return newRole;
        }

        public int DeleteRole(Role roleToDelete)
        {
            _context.Role.Remove(roleToDelete);
            _context.SaveChanges();
            return roleToDelete.RoleId;
        }

        public List<Role> GetAllRoles()
        {
            return _context.Role.ToList();
        }

        public Role GetRoleById(int roleId)
        {
            return _context.Role.FirstOrDefault(x => x.RoleId == roleId);
        }

        public Role GetRoleByName(string roleName)
        {
            return _context.Role.FirstOrDefault(x => x.Name == roleName);
        }

        public Role UpdateRole(Role updatedRole)
        {
            _context.Role.Update(updatedRole);
            _context.SaveChanges();
            return updatedRole;
        }
    }
}
