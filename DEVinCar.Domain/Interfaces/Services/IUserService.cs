using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Interfaces.Services
{
    public interface IUserService
    {
        IList<User> Get();
        User GetById(int id);
        void Inserir(UserDTO car);
        void Excluir (UserDTO car);
    }
}