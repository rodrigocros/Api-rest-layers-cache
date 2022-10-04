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
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _deliveryRepository;
        public DeliveryService(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
            
        }


        public IList<Delivery> Get(int? saleId, int? addressId)
        {
           var query =  _deliveryRepository.Query();

           if (addressId.HasValue)
            {
                query = query.Where(a => a.AddressId == addressId);
            }

            if (saleId != null)
            {
                query = query.Where(s => s.SaleId == saleId);
            }
                      
            if (!query.ToList().Any())
            {
                throw new NaoExisteException("Nao existe endereco informado");
            }

            return query.ToList();
        }
         public Delivery GetById(int id)
        {
            return  _deliveryRepository.ObterPorID(id);
        
        }
        public void Inserir(Delivery delivery)
        {
            _deliveryRepository.Inserir(delivery);
        }

        
    }
}