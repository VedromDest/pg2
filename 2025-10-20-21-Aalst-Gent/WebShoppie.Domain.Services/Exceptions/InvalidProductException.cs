using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShoppie.Domain.Services.Exceptions
{
    public class InvalidProductException : Exception
    {
        public InvalidProductException() : base("Invalid Product. Please contact support.") { }
        public InvalidProductException(string message) : base(message) { }
    }
}
