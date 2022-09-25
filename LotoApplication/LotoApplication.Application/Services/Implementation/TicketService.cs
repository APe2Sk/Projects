using AutoMapper;
using LotoApplication.Application.Dto;
using LotoApplication.Application.Repositories;
using LotoApplication.Domain.Exceptions;
using LotoApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;

//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Application.Services.Implementation
{
    public class TicketService : ITicketService
    {
        private readonly IRepository<Ticket> repository;
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Session> sessionRepository;

        private readonly IMapper mapper;


        public TicketService(IRepository<Ticket> repository, IRepository<User> userRepository, IRepository<Session> sessionRepository, IMapper mapper)
        {
            this.repository = repository;
            this.userRepository = userRepository;
            this.sessionRepository = sessionRepository;
            this.mapper = mapper;
        }

        public TicketDto CreateTicket(CreateTicketDto ticket, int userId)
        {
            var user = userRepository.GetById(userId);
            if (user == null)
                throw new NotFoundException("User not found!");

            //var session = sessionRepository.GetById(sessionId);
            //if(session == null)
            //    throw new NotFoundException("Session not found!");

            var session = sessionRepository.GetAll().Include(x => x.Draw).Include(x => x.Admin).ToList().LastOrDefault();
            if (session == null)
                throw new NotFoundException("Session not found!");

            if (!session.IsActiveSession)
                throw new NotCreateException("You can't create new ticket, because there aren't any active sessions.");


            //var mappedTicket = mapper.Map<TicketDto>(ticket);

            //var a = mappedTicket.Numbers;
            //var b = a.Select(x => mapper.Map<CombinationNumbers>(x)).ToList();

            int[] arr = new int[7];
            var checkNumberRange = ticket.Numbers;
            int i = 0;
            foreach (var number in checkNumberRange)
            {
                arr[i] = number.Number;
                i++;
            }

            foreach (var number in checkNumberRange)
            {
                if (number.Number < 1 || number.Number > 37)
                    throw new OutOfRangeException("The inputted numbers should be between 1 and 37, the inputted numbers exceed the range.");
            }

            var duplicates = arr.GroupBy(x => x)
              .Where(g => g.Count() > 1)
              .Select(y => y.Key)
              .ToList();

            if (duplicates.Count > 0)
                throw new CanNotCreateException("The inputted numbers canno't be dubbled.");


            var numbers = ticket.Numbers.Select(x => new CombinationNumbers
            {
                Number = x.Number
            }).ToList();
            var newTicket = new Ticket(numbers, user, session, "", "", 0, DateTime.Now);


            //write string of numbers in data base
            int y = 0;
            foreach(var num in arr)
            {
                if(y == 7)
                    newTicket.TicketNumbers = newTicket.TicketNumbers + $"{num}";

                newTicket.TicketNumbers = newTicket.TicketNumbers + $"{num}, ";
            }

            newTicket.DateOfCreation = DateTime.Now;

            repository.Create(newTicket);

            return mapper.Map<TicketDto>(newTicket);
        }

        public TicketDto DeleteTicket(int ticketId, int userId)
        {
            var ticket = repository.GetAll()
                                .Include(x => x.Player)
                                .Include(x => x.Session)
                                .Include(x => x.Numbers)
                                .FirstOrDefault(x => x.Id == ticketId);

            if(ticket == null)
                throw new NotFoundException("There aren't any tickets id for this user id!");
            if(ticket.Player.Id != userId)
                throw new NotFoundException("There aren't any tickets id for this user id!");

            var deletedTicket = repository.Delete(ticket);

            return mapper.Map<TicketDto>(deletedTicket);
        }

        public IEnumerable<TicketDto> GetAll(int userId)
        {
            var allTickets = repository.GetAll()
                                            .Include(x => x.Player)
                                            .Include(x => x.Session)
                                            .Include(x => x.Numbers);

            var tickets = allTickets.Where(x => x.Player.Id == userId).ToList();
            if(tickets.Count() == 0)
                throw new NotFoundException("There aren't any tickets id's for this user!");

            var mappedTickets = tickets.Select(x => mapper.Map<TicketDto>(x));

            return mappedTickets;
        }

        public TicketDto GetById(int ticketId, int userId)
        {
            var ticket = repository.GetAll()
                .Include(x => x.Player)
                .Include(x => x.Session)
                .Include(x => x.Numbers)                                
                .FirstOrDefault(x => x.Id == ticketId);

            if(ticket == null || ticket.Player.Id != userId)
                throw new NotFoundException("There aren't any tickets id for this user id!");

            return mapper.Map<TicketDto>(ticket);
        }      
    }
}