using LotoApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Application.Dto
{
    public class DrawDto
    {
        public DrawDto()
        {

        }

        public DrawDto(List<DrawNumberDto> drawNumbers)
        {
            DrawNumbers = drawNumbers;
        }
        public List<DrawNumberDto> DrawNumbers { get; set; } = new List<DrawNumberDto>();
        public string DrawedNumbers { get; set; }


    }
}
