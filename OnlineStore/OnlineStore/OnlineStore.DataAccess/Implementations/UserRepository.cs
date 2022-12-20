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
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public int CreateUser(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
            return user.Id;
        }

        public void UpdateUser(User user)
        {
            _context.User.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUserById(User user)
        {
            _context.User.Remove(user);
            _context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _context.User.ToList();
        }

        public User GetByEmail(string email)
        {
            return _context.User.FirstOrDefault(x => x.Email == email);
        }

        public User GetById(int id)
        {
            return _context.User.FirstOrDefault(x => x.Id == id);
        }

    }
}
