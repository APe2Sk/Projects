using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Domain.Entities
{
    public class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        // Customer = 1
        // Admin = 2
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
