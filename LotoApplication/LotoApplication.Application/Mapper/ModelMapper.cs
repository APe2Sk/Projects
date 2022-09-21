using AutoMapper;
using LotoApplication.Application.Dto;
using LotoApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Application.Mapper
{
    public class ModelMapper
    {
        public static MapperConfiguration GetConfiguration()
        {
            MapperConfiguration cfg = new MapperConfiguration(x =>
            {
                x.CreateMap<User, UserDto>().ReverseMap();
                x.CreateMap<CombinationNumbers, CombinationNumbersDto>().ReverseMap();
                x.CreateMap<Session, SessionDto>()
                                        .ForMember(m => m.End, m => m.Ignore())
                                        .ForMember(m => m.Draw, m => m.Ignore())
                                        .ReverseMap();
                x.CreateMap<Ticket, TicketDto>().ReverseMap();

                //x.CreateMap<TicketDto, Ticket>()
                //            .ForMember(m => m.IsWinner, m => m.Ignore())
                //            .ForMember(m => m.Id, m => m.Ignore());

                x.CreateMap<Winner, WinnerDto>().ReverseMap();
                x.CreateMap<Admin, AdminDto>().ReverseMap();
                x.CreateMap<CreateAdminDto, AdminDto>().ReverseMap();
                x.CreateMap<CreateAdminDto, Admin>().ReverseMap();
                x.CreateMap<CreateUserDto, UserDto>().ReverseMap();
                x.CreateMap<CreateUserDto, User>().ReverseMap();
                x.CreateMap<Draw, DrawDto>().ReverseMap();
                x.CreateMap<DrawNumber, DrawNumberDto>().ReverseMap();


                x.CreateMap<CreateSessionDto, SessionDto>()
                                        .ForMember(m => m.End, m => m.Ignore())
                                        .ForMember(m => m.Draw, m => m.Ignore());

                x.CreateMap<CreateTicketDto, TicketDto>()
                        .ForMember(m => m.Player, m => m.Ignore())
                        .ForMember(m => m.Session, m => m.Ignore());

                x.CreateMap<TicketDto, Ticket>()
                        .ForMember(m => m.Player, m => m.Ignore())
                        .ForMember(m => m.Session, m => m.Ignore())
                        .ForMember(m => m.WinningNumbers, m => m.Ignore())
                        .ForMember(m => m.WinningNums, m => m.Ignore());
            });

            return cfg;
        }
    }
}
