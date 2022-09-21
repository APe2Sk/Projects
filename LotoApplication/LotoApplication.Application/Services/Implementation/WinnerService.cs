using AutoMapper;
using LotoApplication.Application.Dto;
using LotoApplication.Application.Repositories;
using LotoApplication.Domain.Exceptions;
using LotoApplication.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Application.Services.Implementation
{
    public class WinnerService : IWinnerService
    {
        private readonly IRepository<Winner> repository;
        private readonly IRepository<Ticket> ticketRepository;
        private readonly IMapper mapper;

        public WinnerService(IRepository<Winner> repository, IRepository<Ticket> ticketRepository, IMapper mapper)
        {
            this.repository = repository;
            this.ticketRepository = ticketRepository;
            this.mapper = mapper;
        }

        public IEnumerable<WinnerDto> GetAllWinners()
        {
            var winners = repository.GetAll()
                .Include(x => x.Ticket)
                .ToList();
            if (winners == null)
                throw new NotFoundException("There aren't any winners yet.");

            var mappedWinners = winners.Select(x => mapper.Map<WinnerDto>(x));

            return mappedWinners;
        }

        public IEnumerable<WinnerDto> GetAllWinnersForUser(int userId)
        {
            var winners = repository.GetAll()
                .Include(x => x.Ticket)
                .Include(x => x.Ticket.Session)
                //.Include(x => x.Ticket.Session.Draw)
                //.Include(x => x.Ticket.Session.Admin)
                .Include(x => x.Ticket.Player)
                .Where(x => x.Ticket.Player.Id == userId)
                .ToList();
            if (winners.Count == 0)
                throw new NotFoundException("There aren't any winners yet.");

            var mappedWinners = winners.Select(x => mapper.Map<WinnerDto>(x));

            return mappedWinners;
        }

        public WinnerDto GetWinnerByTicketId(int ticketId)
        {
            var winner = repository.GetAll()
                .Include(x => x.Ticket)
                .FirstOrDefault(x => x.Ticket.Id == ticketId);
            if (winner == null)
                throw new NotFoundException("This ticket ID is not winning ticket.");

            return mapper.Map<WinnerDto>(winner);
        }

        public IEnumerable<WinnerDto> GetAllWinnersForSession(int sessionId)
        {
            var winningSessionTickets = repository.GetAll()
                .Include(x => x.Ticket)
                .Where(x => x.Ticket.Session.Id == sessionId)
                .ToList();
            if (winningSessionTickets.Count == 0)
                throw new NotFoundException("Invalid session ID.");

            return winningSessionTickets.Select(x => mapper.Map<WinnerDto>(x));
        }
        public IEnumerable<WinnerDto> GenerateWinners(DrawDto draw)
        {
            var allSessionTickets = ticketRepository.GetAll()
                .Include(x => x.Player)
                .Include(x => x.Session)
                .Include(x => x.Numbers)
                .Where(x => x.Session.IsActiveSession == true)
                .ToList();
            if (allSessionTickets == null)
                throw new OutOfRangeException("There aren't tickets for this session");

            var drawedNumbers = draw.DrawNumbers.ToList();

            var listOfWinners = new List<WinnerDto>();

            foreach (Ticket ticket in allSessionTickets)
            {
                //List<int> ticketNumbers = new List<int>();
                var ticketNumbers = ticket.Numbers.ToList();
                string winningNumbers = "";
                int winningNumbersLenght = 0;

                foreach (var number in ticketNumbers)
                {
                    foreach (var drawNumber in drawedNumbers)
                    {
                        if (number.Number == drawNumber.Number)
                        {
                            winningNumbersLenght++;
                            winningNumbers += $"{number.Number}. ";
                        }

                    }
                }

                var sessionId = ticket.Session.Id;
                string[] prizeName = { "Fifty dollars gift card", "Hundred dollars gift card", "TV", "Vacation", "JackPot! Car." };

                ticket.WinningNumbers = winningNumbers;
                ticket.WinningNums = winningNumbersLenght;

                ticketRepository.Update(ticket);

                if (winningNumbersLenght >= 3)
                {
                    var winnerDto = new WinnerDto
                    {
                        Ticket = mapper.Map<TicketDto>(ticket),
                        PrizeId = (Domain.PizeEnum)winningNumbersLenght,
                        PrizeName = prizeName[winningNumbersLenght-3],
                        SessionId = sessionId,
                        WinningNumbers = winningNumbers,
                    };
                    listOfWinners.Add(winnerDto);

                    var mappedWinner = new Winner
                    {
                        Ticket = ticket,
                        PrizeId = winnerDto.PrizeId,
                        PrizeName = prizeName[winningNumbersLenght-3],
                        SessionId = sessionId,
                        WinningNumbers = winningNumbers,
                    };

                    repository.Create(mappedWinner);
                }
            }

            return listOfWinners;
        }
    }
}
