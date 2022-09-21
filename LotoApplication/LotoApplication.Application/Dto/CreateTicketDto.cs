using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Application.Dto
{
    public class CreateTicketDto
    {
        [MinLength(7)]
        [MaxLength(7)]
        //[Range(1, 37)]
        public IList<CombinationNumbersDto> Numbers { get; set; } = new List<CombinationNumbersDto>();
    }
}
