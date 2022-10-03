using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Interfaces.Services
{
    public interface IDeliveryService
    {
        IList<Delivery> Get(int? addressId, int? saleId);
        Delivery GetById(int id);

    }
}