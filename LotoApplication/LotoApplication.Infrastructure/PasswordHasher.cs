using LotoApplication.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace LotoApplication.Infrastructure
{
    public class PasswordHasher
        : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            var data = ASCIIEncoding.ASCII.GetBytes(password);
            var shaProvider = new SHA1CryptoServiceProvider();
            return ASCIIEncoding.ASCII.GetString(shaProvider.ComputeHash(data));
        }
    }
}
