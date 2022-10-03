using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Exceptions;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Service
{
    public class CarService : ICarService
    {
        private readonly ISaleCarService _selecarservice;
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository, ISaleCarService selecarservice)
        { 
            _carRepository = carRepository;
            _selecarservice = selecarservice;

        }

        public void Excluir(Car car)
        {
            _carRepository.Excluir(car);
        }

        public IList<Car> Get()
        {
            return _carRepository.ObterTodos();
        }

        public Car GetById(int id)
        {
            return _carRepository.ObterPorID(id);
        }

        public void Inserir(Car car)
        {
            _carRepository.Inserir(car);
        }

        public IList<Car> GetFiltered(string name, decimal? priceMin,decimal? priceMax){
            var query = _carRepository.Query();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.Name.Contains(name));
            }if (priceMin > priceMax)
            {
                throw new NaoExisteException("Nao existe no banco de dados");
            }
            if (priceMin.HasValue)
            {
                query = query.Where(c => c.SuggestedPrice >= priceMin);
            }
            if (priceMax.HasValue)
            {
                query = query.Where(c => c.SuggestedPrice <= priceMax);
            }
            if (!query.ToList().Any())
            {
                throw new NaoExisteException("Nao existe no banco de dados");
            }
            return query.ToList();
            
        }

        public SaleCar GetSaleCarPorId(int id){
            return _selecarservice.GetById(id);
        }
    }
}