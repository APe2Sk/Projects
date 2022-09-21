using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Application.Dto
{
    public class CreateSessionDto
    {

        public AdminDto Admin { get; set; }
        public bool IsActiveSession { get; set; } = true;
        public DateTime Start { get; set; }
    }
}
