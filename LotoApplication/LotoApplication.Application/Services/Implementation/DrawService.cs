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
    public class DrawService : IDrawService
    {
        private readonly IRepository<Draw> repository;
        private readonly IRepository<Session> sessionRepository;
        private readonly IRepository<Admin> adminRepository;
        private readonly IMapper mapper;

        public DrawService(IRepository<Draw> repository, IRepository<Session> sessionRepository, IRepository<Admin> adminRepository, IMapper mapper)
        {
            this.repository = repository;
            this.sessionRepository = sessionRepository;
            this.adminRepository = adminRepository;

            this.mapper = mapper;
        }
        public DrawDto GenerateDrawNumbers(int adminId)
        {
            var currentSession = sessionRepository.GetAll().Include(x => x.Draw).Include(x => x.Admin).ToArray().OrderBy(x => x.Id).LastOrDefault();
            if (currentSession == null)
                throw new NotFoundException("Session not found!");

            if (!currentSession.IsActiveSession)
                throw new NotCreateException("There aren't any active sessions right now.");

            var admin = adminRepository.GetAll().FirstOrDefault(x => x.Id == adminId);
            if (admin == null)
                throw new CanNotCreateException("Only admin's can manipulate with sessions in the system.");


            List<DrawNumberDto> drawNums = new List<DrawNumberDto>();

            Random random = new Random();
            var winningNums = Enumerable.Range(1, 37)
                                    .OrderBy(x => random.Next())
                                    .Take(8)
                                    .ToList();

            for (int i = 0; i < 8; i++)
            {
                DrawNumberDto drawNumbers = new DrawNumberDto();

                //drawNumbers.Id = i;
                drawNumbers.Number = winningNums[i];

                drawNums.Add(drawNumbers);
            }

            var newDrawDto = new DrawDto(drawNums);

            var newDrawNumberMap = newDrawDto.DrawNumbers.Select(x => mapper.Map<DrawNumber>(x)).ToList();
            var newDrawMap = new Draw(newDrawNumberMap, "");

            int y = 0;
            foreach(var drawNumber in drawNums)
            {
                if(y == 7)
                    newDrawDto.DrawedNumbers = newDrawDto.DrawedNumbers + $"{drawNumber.Number}";
                newDrawDto.DrawedNumbers = newDrawDto.DrawedNumbers + $"{drawNumber.Number}, ";
            }

            repository.Create(mapper.Map<Draw>(newDrawDto));

            return newDrawDto;
        }
    }
}
