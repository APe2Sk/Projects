using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Domain.Models
{
    public class Admin
    {
        public Admin()
        {

        }

        public Admin(string firstName, string lastName, string adress, string userName, string password, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Adress = adress;
            UserName = userName;
            Password = password;
            Email = email;
        }
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
        public string Adress { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
