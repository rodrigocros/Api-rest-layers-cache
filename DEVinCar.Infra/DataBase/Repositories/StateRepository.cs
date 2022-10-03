using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Models;

namespace DEVinCar.Infra.DataBase.Repositories
{
    public class StateRepository : BaseRepository<State, int>, IStateRepository
    {
        public StateRepository(DevInCarDbContext context) : base(context)
        {
        }

    }
    
}