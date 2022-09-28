using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Models;

namespace DEVinCar.Infra.DataBase.Repositories
{
    public class CarRepository : BaseRepository<Car, int> ,ICarRepository
    {
        public CarRepository(DevInCarDbContext context) : base (context)
        {
            context = _context;
        }
        
    }
}