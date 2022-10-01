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
    public class AddressService : IAddressService
    {
        private readonly IAddressResitory _addressRepository;
        public AddressService(IAddressResitory addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public void Excluir(Address adress)
        {
            throw new NotImplementedException();
        }

        public IList<Address> Get()
        {
            throw new NotImplementedException();
        }

        public Address GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Address adress)
        {
            throw new NotImplementedException();
        }

        public IList<Address> GetList(int? cityId,int? stateId,string street,string cep)
        {
            var query = _addressRepository.Query();

            if (cityId.HasValue)
            {
                query = query.Where(a => a.CityId == cityId);
            }
            if (stateId.HasValue)
            {
                query = query.Where(a => a.City.StateId == stateId);
            }

            if (!string.IsNullOrEmpty(street))
            {
                street = street.ToUpper();
                query = query.Where(a => a.Street.Contains(street));
            }

            if (!string.IsNullOrEmpty(cep))
            {
                query = query.Where(a => a.Cep == cep);
            }

            if (!query.ToList().Any())
            {
                throw new NaoExisteException("nao existe");
            }

            return query.ToList();
            


        }

    }
}