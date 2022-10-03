using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Service
{
    public class LoginService : ILoginService
    {
        private readonly IUserRepository _userRepository;
         LoginService(IUserRepository userRepository)
        {
            userRepository = _userRepository;
        }

        public User ObterPorUsuarioESenha(string email, string password){

            return _userRepository.GetByEmailPassword(email, password);

        }
    }
}