using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Interfaces.Services
{
    public interface ISaleService
    {
        IList<Sale> Get();
        Sale GetById(int id);
        void Inserir(Sale sale);
        void Excluir (Sale sale);
        List<Sale> SaleAsQueryable();


    }
}