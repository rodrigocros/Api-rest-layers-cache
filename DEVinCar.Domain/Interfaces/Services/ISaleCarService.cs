using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Interfaces.Services
{
    public interface ISaleCarService
    {
        IList<SaleCar> Get();
        SaleCar GetById(int id);
        void Inserir(SaleCar saleCar);
        void Excluir (SaleCar saleCar);
    }
}