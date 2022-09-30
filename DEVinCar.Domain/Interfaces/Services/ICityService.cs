using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Interfaces.Services
{
    public interface ICityService
    {
        IList<City> Get();
        City GetById(int id);
        void Inserir(City city);
        void Excluir (City city);
    }
}