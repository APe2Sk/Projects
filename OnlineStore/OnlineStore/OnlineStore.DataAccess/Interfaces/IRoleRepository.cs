using OnlineStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.DataAccess.Interfaces
{
    public interface IRoleRepository
    {
        Role CreateRole(Role newRole);
        Role UpdateRole(Role updatedRole);
        int DeleteRole(Role roleToDelete);
        List<Role> GetAllRoles();
        Role GetRoleById(int roleId);
        Role GetRoleByName(string roleName);

    }
}
