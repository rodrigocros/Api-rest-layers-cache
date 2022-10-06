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
        Sale GetById(int id);
        void Inserir(Sale sale);
        Sale PostSaleById(int id, SaleDTO saleDTO);




    }
}