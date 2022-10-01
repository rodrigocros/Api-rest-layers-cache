using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<User, int>
    {   
        User GetByEmail(String email);

    }
}