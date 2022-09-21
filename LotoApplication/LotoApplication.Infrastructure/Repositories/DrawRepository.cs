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
    public class DrawRepository : IRepository<Draw>
    {
        private ApplicationDbContext _context;

        public DrawRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Draw Create(Draw entity)
        {
            _context.Draw.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Draw Delete(Draw entity)
        {
            _context.Draw.Remove(entity);
            _context.SaveChanges();
            return entity;
        }

        public IQueryable<Draw> GetAll()
        {
            return _context.Draw.AsQueryable();
        }

        public Draw GetById(int id)
        {
            return _context.Draw.FirstOrDefault(x => x.Id == id);
        }

        public Draw Update(Draw entity)
        {
            _context.Draw.Update(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
