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
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository saleRepository;
        public SaleService(ISaleRepository _saleRepository)
        {
            saleRepository = _saleRepository;   
        }

        public void Excluir(SaleDTO car)
        {
            throw new NotImplementedException();
        }

        public IList<Sale> Get()
        {
            throw new NotImplementedException();
        }

        public Sale GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Inserir(SaleDTO car)
        {
            throw new NotImplementedException();
        }
    }
}