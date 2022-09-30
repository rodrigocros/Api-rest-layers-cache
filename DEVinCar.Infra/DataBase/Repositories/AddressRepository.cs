using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Models;

namespace DEVinCar.Infra.DataBase.Repositories
{
    public class AddressRepository : BaseRepository<Address, int> , IAddressResitory
    {
        public AddressRepository(DevInCarDbContext context) : base(context)
        {
        }
    }
}