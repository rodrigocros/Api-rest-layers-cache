using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Infra.DataBase;
using DEVinCar.Infra.DataBase.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DEVinCar.Di
{
    public static class DI
    {
        public static IServiceCollection Register(this IServiceCollection services)
        {
            
            services.AddDbContext<DevInCarDbContext>();

            services.AddScoped<IAddressResitory, AddressRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IDeliveryRepository, DeliveryRepository>();
            services.AddScoped<ISaleCarRepository, SaleCarRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<IStateRepository, StateRepository>();
            services.AddScoped<IUserRepository, UserRepository>();


            return services;
            
        }
    }
}