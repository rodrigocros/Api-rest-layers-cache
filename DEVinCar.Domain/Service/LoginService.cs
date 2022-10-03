using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DEVinCar.Domain.DTOs;
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
            _userRepository = userRepository;
        }

        public User ObterPorUsuarioESenha(UserLoginDTO userloginDTO){

            var user =  _userRepository.GetByEmailPassword(userloginDTO);
            return user;
        }
    }
}