using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Service
{
    public class SaleCarService : ISaleRepository
    {
        private readonly ISaleRepository _saleRepository;
        public SaleCarService(ISaleRepository saleRepository)
        {
            saleRepository = _saleRepository ;   
        }

        public void Atualizar(Sale entity)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Sale entity)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Sale entity)
        {
            throw new NotImplementedException();
        }

        public Sale ObterPorID(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Sale> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}