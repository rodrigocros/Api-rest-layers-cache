using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;
using DEVinCar.Domain.ViewModels;

namespace DEVinCar.Domain.Service
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _staterepository;
        private readonly ICityRepository _cityrepository;
        private readonly ICityService   _cityService;
        private readonly IAddressService _addressService;

        public StateService(IStateRepository staterepository, ICityRepository cityrepository,ICityService cityService, IAddressService addressService)
        {
            _staterepository = staterepository;
            _cityrepository = cityrepository;
            _cityService = cityService;
            _addressService = addressService;
        }


        public IList<State> Get()
        {
            return _staterepository.ObterTodos();
        }

        public State GetById(int id)
        {
            return _staterepository.ObterPorID(id);
        }


        public City GetCitiesByName(string name)
        {
            return _cityService.GetByName(name);
        }
        public void InserirOnCity(City city)
        {
            _cityrepository.Inserir(city);
        }
        public City GetCityById(int id)
        {
            return _cityrepository.ObterPorID(id);
        }
        public void InsertOnAdress(Address adress){
            _addressService.Inserir(adress);
        }
        public List<State> GetListByName(string name){
            // var todosState = _staterepository.ObterTodos();
            // var state = todosState.Where(c => c.Name == name);
            // return state.FirstOrDefault();
             var query = _staterepository.Query();

              // var query = _context.States.AsQueryable();

            if(!string.IsNullOrEmpty(name)) {
                query = query.Where(s => s.Name.ToUpper().Contains(name.ToUpper()));
            }
           
            return query.ToList();
            
        }

        public IQueryable GetCitiesAsQueryable()
        {
            return _cityrepository.Query();
        }
        public State GetStatebyName(string name){

            var query = _staterepository.Query();

            query = query.Where(s => s.Name.ToUpper().Contains(name.ToUpper()));
            
            return query.FirstOrDefault();
        
        }
    }
}