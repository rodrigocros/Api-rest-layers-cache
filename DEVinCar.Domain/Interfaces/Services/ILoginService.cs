using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Interfaces.Services
{
    public interface ILoginService
    {
        User ObterPorUsuarioESenha(String Email, string password);

    }
}