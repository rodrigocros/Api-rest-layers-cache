using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Interfaces.Services
{
    public interface IStateService
    {
        IList<State> Get();
        State GetById(int id);
        void Inserir(StateDTO car);
        void Excluir (StateDTO car);
    }
}