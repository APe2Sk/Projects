using LotoApplication.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Application.Services
{
    public interface IWinnerService
    {
        public IEnumerable<WinnerDto> GenerateWinners(DrawDto draw);
        WinnerDto GetWinnerByTicketId(int ticketId);
        IEnumerable<WinnerDto> GetAllWinnersForUser(int userId);
        IEnumerable<WinnerDto> GetAllWinners();
        IEnumerable<WinnerDto> GetAllWinnersForSession(int sessionId);

    }
}
