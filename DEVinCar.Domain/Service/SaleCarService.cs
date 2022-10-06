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
    public class SaleCarService : ISaleCarService
    {
        private readonly ISaleCarRepository _salecarRepository;
        public SaleCarService(ISaleCarRepository salecarRepository)
        {
            _salecarRepository = salecarRepository ;   
        }

        public SaleCar GetById(int id)
        {
           return _salecarRepository.ObterPorID(id);
        }

        public void Inserir(SaleCar salecar)
        {
            _salecarRepository.Inserir(salecar);
        }
    }
}