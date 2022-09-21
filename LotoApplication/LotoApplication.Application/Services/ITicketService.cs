using LotoApplication.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Application.Services
{
    public interface ITicketService
    {
        IEnumerable<TicketDto> GetAll(int userId);
        TicketDto GetById(int ticketId, int userId);
        TicketDto CreateTicket(CreateTicketDto ticket, int userId);
        TicketDto DeleteTicket(int ticketId, int userId);
    }
}
