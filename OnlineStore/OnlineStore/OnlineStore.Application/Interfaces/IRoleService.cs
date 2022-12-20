using OnlineStore.ViewModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Application.Interfaces
{
    public interface IRoleService
    {
        RoleViewModel CreateRole (RoleViewModel role);
        RoleViewModel UpdateRole (RoleViewModel role, int roleId);
        int DeleteRole (int roleId);
        RoleViewModel GetRoleById (int roleId);
        RoleViewModel GetRoleByName (string roleName);
        List<RoleViewModel> GetAllRole();
    }
}
