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
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository)
        { 
            carRepository = _carRepository;
        }

        public void Excluir(CarDTO car)
        {
            throw new NotImplementedException();
        }

        public IList<Car> Get()
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Inserir(CarDTO car)
        {
            throw new NotImplementedException();
        }
    }
}