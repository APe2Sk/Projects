using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApplication.Domain.Exceptions
{
    public class CanNotCreateException : Exception
    {
        public CanNotCreateException()
        {
        }

        public CanNotCreateException(string? message) : base(message)
        {
        }

        public CanNotCreateException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}
