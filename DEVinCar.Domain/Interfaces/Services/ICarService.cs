using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.DTOs;

namespace DEVinCar.Domain.Interfaces.Services
{
    public interface ICarService
    {
        IList<CarDTO> ObterTodos();
        CarDTO ObterPorID(int id);
        void Inserir(CarDTO car);
        void Excluir (CarDTO car);
    }
}