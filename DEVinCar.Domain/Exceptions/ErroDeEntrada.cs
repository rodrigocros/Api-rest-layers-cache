using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Exceptions
{
    public class ErroDeEntrada : Exception
    {
        public ErroDeEntrada()
        {
        }

        public ErroDeEntrada(string message) : base (message)
        {
        }
    }
}