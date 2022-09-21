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
    public class SessionService : ISessionService
    {
        private readonly IRepository<Session> sessionRepository;
        private readonly IRepository<Draw> drawRepository;
        private readonly IRepository<Admin> adminRepository;
        private readonly IRepository<Ticket> ticketRepository;



        private readonly IMapper mapper;

        public SessionService(IRepository<Session> sessionRepository, IRepository<Draw> drawRepository, IRepository<Admin> adminRepository, IRepository<Ticket> ticketRepository, IMapper mapper)
        {
            this.sessionRepository = sessionRepository;
            this.drawRepository = drawRepository;
            this.adminRepository = adminRepository;
            this.ticketRepository = ticketRepository;
            this.mapper = mapper;
        }

        public SessionDto CreateSession(int adminId)
        {
            var admin = adminRepository.GetById(adminId);

            if (admin == null)
                throw new NotFoundException("There aren't any admins by that ID!");

            var startDate = DateTime.Now;
            var isActiveSession = true;

            var newSession = new Session(startDate, isActiveSession, admin);

            var activesessions = sessionRepository.GetAll().Include(x => x.Draw).Include(x => x.Admin).Where(x => x.IsActiveSession == true).ToList();

            if (activesessions.Count() >= 1)
                throw new CanNotCreateException("It is not possible to have more than one active sessions!");

            sessionRepository.Create(newSession);

            return mapper.Map<SessionDto>(newSession);
        }

        public SessionDto DeleteSession(int id, int adminId)
        {
            var session = sessionRepository.GetAll().Include(x => x.Draw).Include(x => x.Admin)
                                .FirstOrDefault(x => x.Id == id && x.Admin.Id == adminId);

            if (session == null)
                throw new NotFoundException("There aren't any sessions by that ID created by this admin!");

            sessionRepository.Delete(session);
            return mapper.Map<SessionDto>(session);
        }

        public IEnumerable<SessionDto> GetAllSessions()
        {
            var allSessions = sessionRepository.GetAll().Include(x => x.Draw).Include(x => x.Admin).ToList();

            if(allSessions == null)
                throw new NotFoundException("There aren't any sessions!");

            var mappedSessions = allSessions.Select(x => mapper.Map<SessionDto>(x));
            return mappedSessions;
        }

        public SessionDto GetById(int id)
        {
            var session = sessionRepository.GetAll().Include(x => x.Draw).Include(x => x.Admin).FirstOrDefault(x => x.Id == id);

            if(session == null)
                throw new NotFoundException("There aren't any sessions by that ID!");

            var mappedSession = mapper.Map<SessionDto>(session);
            return mappedSession;
        }

        public SessionDto GetNumbers(int adminId, DrawDto draw)
        {

            var currentSession = sessionRepository.GetAll().Include(x => x.Draw).Include(x => x.Admin).ToArray().OrderBy(x => x.Id).LastOrDefault();
            if (currentSession == null)
                throw new NotFoundException("Session not found!");

            if (!currentSession.IsActiveSession)
                throw new NotCreateException("There aren't any active sessions right now.");

            var admin = adminRepository.GetAll().FirstOrDefault(x => x.Id == adminId);
            if (admin == null)
                throw new CanNotCreateException("Only admin's can manipulate with sessions in the system.");

            var castedNumbers = draw.DrawNumbers.Select(x => new DrawNumber
            {
                Number = x.Number
            });
            var castedDraw = drawRepository.GetAll().Include(x => x.DrawNumbers).ToList().LastOrDefault();
            if(castedDraw == null)
                throw new NotFoundException("Draw not found!");

            currentSession.Draw = castedDraw;

            currentSession.IsActiveSession = false;
            currentSession.End = DateTime.Now;


            sessionRepository.Update(currentSession);

            var mappedSessionDto = new SessionDto
            {
                Start = currentSession.Start,
                End = currentSession.End,
                IsActiveSession = currentSession.IsActiveSession,
                Draw = mapper.Map<DrawDto>(castedDraw),
                Admin = mapper.Map<AdminDto>(admin),
            };

            return mappedSessionDto;
        }
    }
}
