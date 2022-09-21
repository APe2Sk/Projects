using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Domain.Models
{
    public class Winner
    {
        public Winner()
        {

        }
        public int Id { get; set; }
        public Ticket Ticket { get; set; }
        public string WinningNumbers { get; set; }
        public PizeEnum PrizeId { get; set; }
        public string PrizeName { get; set; }
        public int SessionId { get; set; }
    }
}