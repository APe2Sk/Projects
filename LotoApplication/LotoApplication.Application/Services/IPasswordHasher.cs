using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Application.Services
{
    public interface IPasswordHasher
    {
        public string HashPassword(string password);
    }
}
