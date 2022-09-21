using LotoApplication.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Application.Services
{
    public interface IAdminService
    {
        AdminDto GetAdmin(int id);
        IEnumerable<AdminDto> GetAllAdmins();
        AdminDto CreateAdmin(CreateAdminDto admin);
        AdminDto DeleteAdmin(int userId);
        AdminDto UpdateAdmin(CreateAdminDto user, int userId);
        AdminDto PaswordLogin(AdminLoginDto model);

    }
}
