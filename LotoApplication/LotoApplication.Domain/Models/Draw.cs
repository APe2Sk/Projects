using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Domain.Models
{
    public class Draw
    {
        public Draw()
        {

        }

        public Draw(IList<DrawNumber> drawNums, string drawedNumbers)
        {
            DrawNumbers = drawNums;
            DrawedNumbers = drawedNumbers;
        }
        public int Id { get; set; }
        public IList<DrawNumber> DrawNumbers { get; set; } = new List<DrawNumber>();
        public string DrawedNumbers { get; set; }
    }
}
