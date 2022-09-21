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
    public class WinnerRepository : IRepository<Winner>
    {
        private ApplicationDbContext _context;

        public WinnerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Winner Create(Winner entity)
        {
            //var id = context.Winners.LastOrDefault()?.Id ?? 0;
            //entity.Id = ++id;

            _context.Winners.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public Winner Delete(Winner entity)
        {
            _context.Winners.Remove(entity);
            _context.SaveChanges();

            return entity;
        }

        public IQueryable<Winner> GetAll()
        {
            return _context.Winners.AsQueryable();
        }

        public Winner? GetById(int id)
        {
            return _context.Winners.FirstOrDefault(x => x.Id == id);
        }

        public Winner Update(Winner entity)
        {
            //var winner = _context.Winners.FirstOrDefault(x => x.Id == entity.Id);
            //if (winner != null)
            //    winner = entity;
            _context.Winners.Update(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
