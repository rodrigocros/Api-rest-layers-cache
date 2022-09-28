using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Interfaces.Repositories
{
    public interface ICarRepository
    {
        IList<Car> ObterTodos();
        Car ObterPorID(int id);
        void Inserir(Car car);
        void Excluir (Car car);
        
    }
}