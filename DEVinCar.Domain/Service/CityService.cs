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
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityrepository;
        public CityService(ICityRepository cityrepository)
        {
            cityrepository = _cityrepository;   
        }

        public void Excluir(CityDTO car)
        {
            throw new NotImplementedException();
        }

        public IList<City> Get()
        {
            throw new NotImplementedException();
        }

        public City GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Inserir(CityDTO car)
        {
            throw new NotImplementedException();
        }
    }
}