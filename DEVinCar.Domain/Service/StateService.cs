using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Service
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _staterepository;

        public StateService(IStateRepository staterepository)
        {
            _staterepository = staterepository;
        }

        public void Excluir(State state)
        {
            throw new NotImplementedException();
        }

        public IList<State> Get()
        {
            throw new NotImplementedException();
        }

        public State GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Inserir(State state)
        {
            throw new NotImplementedException();
        }
    }
}