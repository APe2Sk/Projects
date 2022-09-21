using LotoApplication.Application.Repositories;
using LotoApplication.Domain.Models;
using LotoApplication.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Infrastructure.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User Create(User entity)
        {
            //var idLast = _context.User.OrderByDescending(p => p.Id).FirstOrDefault()?.Id ?? 0;
            //var id = _context.User.LastOrDefault()?.Id ?? 0;
            //entity.Id = ++idLast;

            _context.User.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public User Delete(User entity)
        {
            _context.User.Remove(entity);
            _context.SaveChanges();

            return entity;
        }

        public IQueryable<User> GetAll()
        {
            return _context.User.AsQueryable();
        }

        public User? GetById(int id)
        {
            return _context.User.FirstOrDefault(x => x.Id == id);
        }

        public User Update(User entity)
        {
            //var user = _context.User.FirstOrDefault(x => x.Id == entity.Id);
            //if (user != null)
            //    user = entity;
            _context.User.Update(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
