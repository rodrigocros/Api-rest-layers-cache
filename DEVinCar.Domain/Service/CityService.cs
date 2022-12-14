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
            _cityrepository = cityrepository;   
        }

        public City GetByName(string name)
        {
            var cityTodos = _cityrepository.Query();
            // var cityTodos =  _cityrepository.ObterTodos();
            var city = cityTodos.Where( c => c.Name == name);
            return city.FirstOrDefault();

        }

    }
}