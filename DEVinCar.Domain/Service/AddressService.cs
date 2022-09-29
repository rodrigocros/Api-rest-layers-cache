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
    public class AddressService : IAddressService
    {
        private readonly IAddressResitory _addressRepository;
        public AddressService(IAddressResitory addressRepository)
        {
            addressRepository = _addressRepository;
        }
        public void Excluir(AdressDTO adress)
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

        public void Inserir(AdressDTO adress)
        {
            throw new NotImplementedException();
        }
    }
}