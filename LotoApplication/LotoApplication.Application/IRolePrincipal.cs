using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Application
{
    public interface IRolePrincipal
    {
        public string Name { get; }
        public int Id { get; }
        public bool IsInRole(string role);
    }
}
