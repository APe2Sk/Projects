using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Application.Dto
{
    public class TicketDto
    {        
        public IList<CombinationNumbersDto> Numbers { get; set; } = new List<CombinationNumbersDto>();
        public UserDto Player { get; set; }
        public SessionDto Session { get; set; }
        public string TicketNumbers { get; set; }
        public string WinningNumebrs { get; set; }
        public int WinningNums { get; set; } = 0;
        public DateTime DateOfCreation { get; set; }

    }
}
