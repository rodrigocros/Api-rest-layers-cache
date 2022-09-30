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
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _carRepository;
        public DeliveryService(IDeliveryRepository carRepository)
        {
            _carRepository = carRepository;
            
        }

        public void Excluir(Delivery delivery)
        {
            throw new NotImplementedException();
        }

        public IList<Delivery> Get()
        {
            throw new NotImplementedException();
        }

        public Delivery GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Delivery delivery)
        {
            throw new NotImplementedException();
        }
    }
}