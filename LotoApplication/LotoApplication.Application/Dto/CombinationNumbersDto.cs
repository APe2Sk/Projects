using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Application.Dto
{
    public class CombinationNumbersDto
    {
        public CombinationNumbersDto(int number)
        {
            Number = number;
        }
        //public int Id { get; set; }
        public int Number { get; set; }

    }
}
