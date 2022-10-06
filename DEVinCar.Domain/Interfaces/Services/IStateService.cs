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
        City GetCitiesByName(string name);
        void InserirOnCity(City city);
        City GetCityById(int id);
        IQueryable GetCitiesAsQueryable();
        void InsertOnAdress(Address adress);
        State GetStatebyName(string name);





    }
}