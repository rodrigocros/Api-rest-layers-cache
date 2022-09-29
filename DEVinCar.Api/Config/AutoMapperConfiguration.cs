using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;

namespace DEVinCar.Api.Config
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Configure()
        {
            var configMap = new MapperConfiguration( config => {
            config.CreateMap<Address,AdressDTO>().ReverseMap();
            config.CreateMap<Car,CarDTO>().ReverseMap();
            config.CreateMap<City,CityDTO>().ReverseMap();
            config.CreateMap<Delivery,DeliveryDTO>().ReverseMap();
            config.CreateMap<SaleCar,SaleCarDTO>().ReverseMap();
            config.CreateMap<Sale,SaleDTO>().ReverseMap();
            config.CreateMap<State,StateDTO>().ReverseMap();
            config.CreateMap<User,UserDTO>().ReverseMap();
        });
            return configMap.CreateMapper();
        }
         
    }
}