using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Models;

namespace DEVinCar.Infra.DataBase.Repositories
{
    public class SaleCarRepository : BaseRepository<SaleCar, int>, ISaleCarRepository
    {
        public SaleCarRepository(DevInCarDbContext context) : base(context)
        {
            context = _context;
        }
    }
}