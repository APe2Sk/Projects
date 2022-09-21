using LotoApplication.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Application.Services
{
    public interface ISessionService
    {
        IEnumerable<SessionDto> GetAllSessions();
        SessionDto GetById(int id); 
        SessionDto DeleteSession(int id, int adminId);
        SessionDto CreateSession(int adminId);
        SessionDto GetNumbers(int adminId, DrawDto draw);
    }
}
