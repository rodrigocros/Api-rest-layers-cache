using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Exceptions
{
    public class JaExisteException : Exception
    {
        public JaExisteException(string message) : base (message)
        {
            
        }
    }
}