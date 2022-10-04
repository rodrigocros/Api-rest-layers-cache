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
    public class SaleService : ISaleService
    {
        private readonly IUserService _userService;
        private readonly ISaleRepository _saleRepository;
        public SaleService(ISaleRepository saleRepository, IUserService userService)
        {
            _userService = userService;
            _saleRepository = saleRepository;   
        }


        public Sale GetById(int id)
        {
            return   _saleRepository.ObterPorID(id);
                
        }

        public void Inserir(Sale sale)
        {
        
            var user = _userService.GetById(sale.SellerId);
            if (user == null)
            {
                throw new NaoExisteException("The user does not exist!");
            }

            var buyer = _userService.GetById(sale.BuyerId);
            if (buyer == null)
            {
                throw new NaoExisteException("The user does not exist!");
            }

             if (sale.SaleDate == null)
            {
                sale.SaleDate = DateTime.Now;
            }

            if (sale.SaleDate.ToString() == null)
            {
                sale.SaleDate = DateTime.Now;
            }

            _saleRepository.Inserir(sale);
        }
        public List<Sale> SaleAsQueryable()
        {
            return (List<Sale>)_saleRepository.Query();
        }
    }
}