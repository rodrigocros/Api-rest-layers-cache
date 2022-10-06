using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Interfaces.Services
{
    public interface ICarService
    {
        IList<Car> Get();
        Car GetById(int id);
        void Inserir(Car car);
        void Excluir (Car car);
        IList<Car> GetFiltered(string name, decimal? priceMin,decimal? priceMax);
        SaleCar GetSaleCarPorId(int id);
        void Atualizar(Car car);


    }
}