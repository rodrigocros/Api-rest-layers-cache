using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.Models;
using DEVinCar.Domain.DTOs;


namespace DEVinCar.Domain.Interfaces.Services
{
    public interface IAddressService
    {
        IList<Address> Get();
        Address GetById(int id);
        void Inserir(Address address);
        void Excluir (Address address);
    }
}