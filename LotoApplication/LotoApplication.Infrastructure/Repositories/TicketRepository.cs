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
    public class TicketRepository : IRepository<Ticket>
    {
        private ApplicationDbContext _context;


        public TicketRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Ticket Create(Ticket entity)
        {
            //var id = context.Tickets.LastOrDefault()?.Id ?? 0;
            //entity.Id = ++id;

            _context.Tickets.Add(entity);
            _context.SaveChanges();

            return entity;
        }

        public Ticket Delete(Ticket entity)
        {
            _context.Tickets.Remove(entity);
            _context.SaveChanges();

            return entity;
        }

        public IQueryable<Ticket> GetAll()
        {
            return _context.Tickets.AsQueryable();
        }

        public Ticket GetById(int id)
        {
            var user = _context.Tickets.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public Ticket Update(Ticket entity)
        {
            //var ticket = _context.Tickets.FirstOrDefault(x => x.Id == entity.Id);
            //if (ticket != null)
            //{
            //    ticket = entity;
            //}

            _context.Tickets.Update(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
