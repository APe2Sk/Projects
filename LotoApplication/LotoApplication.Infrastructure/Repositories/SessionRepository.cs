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
    public class SessionRepository : IRepository<Session>
    {
        private ApplicationDbContext _context;

        public SessionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Session Create(Session entity)
        {
            //var id = _context.Sessions.LastOrDefault()?.Id ?? 0;
            //entity.Id = ++id;

            _context.Sessions.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Session Delete(Session entity)
        {
            _context.Sessions.Remove(entity);
            _context.SaveChanges();

            return entity;
        }

        public IQueryable<Session> GetAll()
        {
            return _context.Sessions.AsQueryable();
        }

        public Session? GetById(int id)
        {
            return _context.Sessions.FirstOrDefault(x => x.Id == id);
        }

        public Session Update(Session entity)
        {
            //var session = _context.Sessions.FirstOrDefault(x => x.Id == entity.Id);
            //if (session != null)
            //    session = entity;

            _context.Sessions.Update(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
