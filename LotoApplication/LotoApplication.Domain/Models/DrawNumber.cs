using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Domain.Models
{
    public class DrawNumber
    {
        public DrawNumber()
        {

        }

        public DrawNumber(int number)
        {
            Number = number;
        }
        public int Id { get; set; }
        public int Number { get; set; }
    }
}
