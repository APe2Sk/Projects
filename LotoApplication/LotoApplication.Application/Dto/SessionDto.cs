using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Application.Dto
{
    public class SessionDto
    {

        public DateTime Start { get; set; }
        public DateTime End { get; set; } = DateTime.MinValue;
        public bool IsActiveSession { get; set; } = true;
        public DrawDto Draw { get; set; }
        public AdminDto Admin { get; set; }
    }
}
