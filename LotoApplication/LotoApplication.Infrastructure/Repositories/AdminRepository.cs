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
    public class AdminRepository : IRepository<Admin>
    {
        private ApplicationDbContext _context;

        public AdminRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Admin Create(Admin entity)
        {
            //var id = context.Admin.LastOrDefault()?.Id ?? 0;
            //entity.Id = ++id;

            _context.Admin.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public Admin Delete(Admin entity)
        {
            _context.Admin.Remove(entity);
            _context.SaveChanges();

            return entity;
        }

        public IQueryable<Admin> GetAll()
        {
            return _context.Admin.AsQueryable();
        }

        public Admin? GetById(int id)
        {
            return _context.Admin.FirstOrDefault(x => x.Id == id);
        }

        public Admin Update(Admin entity)
        {
            //var Admin = _context.Admin.FirstOrDefault(x => x.Id == entity.Id);
            //if (Admin != null)
            //    Admin = entity;

            _context.Admin.Update(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
