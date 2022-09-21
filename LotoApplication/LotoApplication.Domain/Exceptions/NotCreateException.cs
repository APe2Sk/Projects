using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Domain.Exceptions
{
    public class NotCreateException : Exception
    {
        public NotCreateException()
        {
        }

        public NotCreateException(string? message) : base(message)
        {
        }

        public NotCreateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}
