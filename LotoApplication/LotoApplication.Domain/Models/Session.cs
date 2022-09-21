using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Domain.Models
{
    public class Session
    {
        public Session()
        {

        }

        public Session(DateTime start, bool isActive, Admin admin)
        {
            Start = start;
            IsActiveSession = isActive;
            Admin = admin;
        }
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool IsActiveSession { get; set; }
        public Draw? Draw { get; set; }
        public Admin Admin { get; set; }
    }
}
