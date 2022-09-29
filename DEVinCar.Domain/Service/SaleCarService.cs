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
        private readonly ISaleRepository _saleRepository;
        public SaleCarService(ISaleRepository saleRepository)
        {
            saleRepository = _saleRepository ;   
        }

        public void Excluir(SaleCarDTO car)
        {
            throw new NotImplementedException();
        }

        public IList<SaleCar> Get()
        {
            throw new NotImplementedException();
        }

        public SaleCar GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Inserir(SaleCarDTO car)
        {
            throw new NotImplementedException();
        }
    }
}