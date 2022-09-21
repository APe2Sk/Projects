using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Domain.Models
{
    public class Ticket
    {
        public Ticket()
        {

        }

        public Ticket(IList<CombinationNumbers> numbers, User player, Session session, string ticketNumbers, string winningNumbers, int winningNums, DateTime dateOfCreation)
        {
            Numbers = numbers;
            Player = player;
            Session = session;
            TicketNumbers = ticketNumbers;
            WinningNumbers = winningNumbers;
            WinningNums = winningNums;
            dateOfCreation = dateOfCreation;
        }

        public int Id { get; set; }
        public IList<CombinationNumbers> Numbers { get; set; } = new List<CombinationNumbers>();
        public User Player { get; set; }
        public Session Session { get; set; }
        public string TicketNumbers { get; set; }
        public string WinningNumbers { get; set; }
        public int WinningNums { get; set; } = 0;
        public DateTime DateOfCreation { get; set; }
    }
}
